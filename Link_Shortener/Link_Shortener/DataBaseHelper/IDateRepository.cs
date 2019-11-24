using Link_Shortener.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_Shortener.DataBaseHelper
{
    public interface IDateRepository
    {
        public string AddUrl(Url url);

        public bool CheckShortUrl(string shortUrl);

        public string Redirect(string shortUrl);

        public List<Url> GetAllUrls();

        public void DeleteUrl(int Id);
        
        public Url GetUrl(int Id);

        public void EditUrl(Url dtoUrl);


    }
}
