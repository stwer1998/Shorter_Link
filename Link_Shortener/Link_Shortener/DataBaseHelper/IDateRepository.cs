using Link_Shortener.Models;
using System.Collections.Generic;

namespace Link_Shortener.DataBaseHelper
{
    public interface IDateRepository
    {
        /// <summary>
        /// Добавление объекта в бд
        /// </summary>
        /// <param name="url">Объект</param>
        /// <returns>Вернет укороченную ссылку</returns>
        public string AddUrl(Url url);
        /// <summary>
        /// Проверяет не зането ли короткая ссылка
        /// </summary>
        /// <param name="shortUrl"></param>
        /// <returns></returns>
        public bool CheckShortUrl(string shortUrl);
        /// <summary>
        /// По короткой ссылке вернет оргинал
        /// </summary>
        /// <param name="shortUrl"></param>
        /// <returns></returns>
        public string Redirect(string shortUrl);
        /// <summary>
        /// Вернет все сущ-е объекты
        /// </summary>
        /// <returns></returns>
        public List<Url> GetAllUrls();
        /// <summary>
        /// Удаляет объект
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteUrl(int Id);
        /// <summary>
        /// Возвращает объект по Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Url GetUrl(int Id);
        /// <summary>
        /// Редактирует объект
        /// </summary>
        /// <param name="dtoUrl"></param>
        public void EditUrl(Url dtoUrl);
    }
}
