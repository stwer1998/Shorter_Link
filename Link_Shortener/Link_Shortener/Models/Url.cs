using System;
using System.ComponentModel.DataAnnotations;

namespace Link_Shortener.Models
{
    public class Url
    {
        /// <summary>
        /// Id класса для идентификации
        /// </summary>
        [Key]
        public int Id { get; private set; }//так как можно менять short long Link клячод делаем Id
        /// <summary>
        /// Оргинальная ссылка
        /// </summary>
        public string LongLink { get; set; }
        /// <summary>
        /// Укороченная ссылка
        /// </summary>
        public string ShortLink { get; set; }
        /// <summary>
        /// Врамя создание объекта
        /// </summary>
        public DateTime CreateDate { get; private set; }
        /// <summary>
        /// Кол-во переходов по ссылке
        /// </summary>
        public int CountTransition { get; set; }

        public Url()
        {
                
        }
        public Url(string link,string shortLink)
        {
            LongLink = link;
            ShortLink = shortLink;
            CreateDate = DateTime.Now;
            CountTransition=0;
        }
    }
}
