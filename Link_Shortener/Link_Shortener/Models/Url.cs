using System;
using System.ComponentModel.DataAnnotations;

namespace Link_Shortener.Models
{
    public class Url
    {
        [Key]
        public int Id { get; private set; }

        public string LongLink { get; set; }
        
        public string ShortLink { get; set; }

        public DateTime CreateDate { get; private set; }

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
