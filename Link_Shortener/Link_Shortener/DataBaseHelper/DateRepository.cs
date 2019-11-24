using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Shortener.Models;

namespace Link_Shortener.DataBaseHelper
{
    public class DateRepository : IDateRepository
    {
        private MyDbContext db;
        public DateRepository(MyDbContext db)
        {

            this.db = db;
        }
        public string AddUrl(Url url)
        {
            var u = db.Urls.FirstOrDefault(x=>x.LongLink==url.LongLink);
            if (u == null)
            {
                db.Urls.Add(url);
                db.SaveChanges();
                return url.ShortLink;
            }
            else return u.ShortLink;
        }

        public bool CheckShortUrl(string shortUrl)
        {
            var sh = db.Urls.FirstOrDefault(x=>x.ShortLink==shortUrl);
            if (sh != null && sh.ShortLink == shortUrl)
            {
                return false;
            }
            else return true;
        }

        public void DeleteUrl(int Id)
        {
            db.Urls.Remove(db.Urls.FirstOrDefault(x=>x.Id==Id));
            db.SaveChanges();
        }

        public void EditUrl(Url dtoUrl)
        {
            var url = db.Urls.FirstOrDefault(x => x.Id == dtoUrl.Id);
            url.LongLink = dtoUrl.LongLink;
            url.ShortLink = dtoUrl.ShortLink;
            db.SaveChanges();
        }

        public List<Url> GetAllUrls()
        {
            return db.Urls.ToList();
        }

        public Url GetUrl(int Id)
        {
            return db.Urls.FirstOrDefault(x => x.Id == Id);
        }

        public string Redirect(string shortUrl)
        {
            var url = db.Urls.FirstOrDefault(x=>x.ShortLink==shortUrl);
            if (url != null && url.ShortLink == shortUrl)
            {
                url.CountTransition++;
                db.SaveChanges();
                return url.LongLink;
            }
            else return "Wrong link!!!";
        }
    }
}
