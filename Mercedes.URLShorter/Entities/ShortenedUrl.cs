using System.ComponentModel.DataAnnotations;

public class ShortenedUrl
{
    public int Id { get; set; }
    [MaxLength(6)]
    public string ShortUrl { get; set; }
    public string LongUrl { get; set; }
}