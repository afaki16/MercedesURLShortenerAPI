using System.ComponentModel.DataAnnotations;

namespace Mercedes.URLShorter.Models
{
    public class UrlShortCustomInput
    {
        [MaxLength(6)]
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }
    }
}
