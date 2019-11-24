namespace Link_Shortener.Models
{
    public class DtoUrl//этот клас нужен при редактирование основного объекта
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
