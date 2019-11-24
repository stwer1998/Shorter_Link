using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Добавление объекта в бд
        /// </summary>
        /// <param name="url">Объект</param>
        /// <returns>Вернет укороченную ссылку</returns>
        public string AddUrl(Url url)
        {
            var u = db.Urls.FirstOrDefault(x=>x.LongLink==url.LongLink);
            if (u == null)//если такая ссылка уже укороченна то вернем старую укороченную ссылку что не было дублирование
            {
                db.Urls.Add(url);
                db.SaveChanges();
                return url.ShortLink;
            }
            else return u.ShortLink;
        }
        /// <summary>
        /// Проверяет не зането ли короткая ссылка
        /// </summary>
        /// <param name="shortUrl"></param>
        /// <returns></returns>
        public bool CheckShortUrl(string shortUrl)
        {
            var sh = db.Urls.FirstOrDefault(x=>x.ShortLink==shortUrl);
            if (sh != null && sh.ShortLink == shortUrl)
            {
                return false;
            }
            else return true;
        }

        /// <summary>
        /// Удаляет объект
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteUrl(int Id)
        {
            db.Urls.Remove(db.Urls.FirstOrDefault(x=>x.Id==Id));
            db.SaveChanges();
        }
        /// <summary>
        /// Возвращает объект по Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public void EditUrl(Url dtoUrl)
        {
            var url = db.Urls.FirstOrDefault(x => x.Id == dtoUrl.Id);
            url.LongLink = dtoUrl.LongLink;
            url.ShortLink = dtoUrl.ShortLink;
            db.SaveChanges();
        }
        /// <summary>
        /// Вернет все сущ-е объекты
        /// </summary>
        /// <returns></returns>
        public List<Url> GetAllUrls()
        {
            return db.Urls.ToList();
        }
        /// <summary>
        /// Удаляет объект
        /// </summary>
        /// <param name="Id"></param>
        public Url GetUrl(int Id)
        {
            return db.Urls.FirstOrDefault(x => x.Id == Id);
        }
        /// <summary>
        /// Вернет все сущ-е объекты
        /// </summary>
        /// <returns></returns>
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
