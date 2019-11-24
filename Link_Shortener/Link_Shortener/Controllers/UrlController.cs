using System.Security.Cryptography;
using System.Text;
using Link_Shortener.DataBaseHelper;
using Link_Shortener.Models;
using Microsoft.AspNetCore.Mvc;

namespace Link_Shortener.Controllers
{
    public class UrlController : Controller
    {
        private IDateRepository db;

        public UrlController(IDateRepository db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult CreateShortUrl() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateShortUrl(string url) 
        {
            var a = new Url(url, Shorter());
            var res=db.AddUrl(a);
            
            return View("ShortUrl",Request.Scheme+"://"+Request.Host+ "/" + res);
        }

        public IActionResult DeleteUrl(int Id) 
        {
            db.DeleteUrl(Id);
            return RedirectToAction("GetAllUrls");
        }

        [HttpGet]
        public IActionResult Edit(int Id) 
        {
            return View(new DtoUrl(db.GetUrl(Id)));
        }

        [HttpPost]
        public IActionResult Edit(DtoUrl dtoUrl)
        {
            var origin = db.GetUrl(dtoUrl.Id);
            if (origin.ShortLink == dtoUrl.ShortLink || db.CheckShortUrl(dtoUrl.ShortLink))
            {
                origin.ShortLink = dtoUrl.ShortLink;
                origin.LongLink = dtoUrl.LongLink;
                db.EditUrl(origin);
                return RedirectToAction("GetAllUrls");
            }
            else 
            {
                ModelState.AddModelError("ShortLink", "Choise another short name");
                return View(dtoUrl);
            }
        }
       
        public IActionResult GetAllUrls() 
        {
            return View(db.GetAllUrls());
        }
        [HttpGet, Route("/{url}")]
        public IActionResult RedirectFrom(string url) 
        {
            var link = db.Redirect(url);
            if (link == "Wrong link!!!") 
            {
                return NotFound();
            }
            else  return new RedirectResult(link);            
        }

        private string Shorter() 
        {
            string result=GetUniqueKey(3);
            while (!db.CheckShortUrl(result)) 
            {
                result = GetUniqueKey(3);
            }
            return result;
        }

        private string GetUniqueKey(int size)
        {
            char[] chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
    }
}