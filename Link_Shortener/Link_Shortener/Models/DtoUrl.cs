using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_Shortener.Models
{
    public class DtoUrl
    {
        public int Id { get; set; }

        public string LongLink { get; set; }

        public string ShortLink { get; set; }

        public DtoUrl()
        {

        }

        public DtoUrl(Url url)
        {
            Id = url.Id;
            LongLink = url.LongLink;
            ShortLink = url.ShortLink;
        }
    }
}
