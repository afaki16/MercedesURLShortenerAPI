using Mercedes.URLShorter;

public class ShortenedUrlRepository
{
    private readonly ShorterDBContext _context;
    private readonly List<ShortenedUrl> _shortenedUrls = new List<ShortenedUrl>();
    public ShortenedUrlRepository(ShorterDBContext context)
    {
            //_context = new ShorterDBContext();
            _context = context;
    }
    public ShortenedUrl GetShortenedUrl(string shortUrl)
    {
        return _context.ShortenedUrls.FirstOrDefault(x=>x.ShortUrl == shortUrl);
        
    }
     public ShortenedUrl GetLongUrl(string longUrl)
    {
        return _context.ShortenedUrls.FirstOrDefault(x=>x.LongUrl == longUrl);
        
    }

    public bool ExistShortUrl(string shortUrl)
    {
        return _context.ShortenedUrls.Any(x => x.ShortUrl == shortUrl);

    }
    public bool ExistLongUrl(string longUrl)
    {
        return _context.ShortenedUrls.Any(x => x.LongUrl == longUrl);

    }
    



    public ShortenedUrl AddShortenedUrl(string shortUrl, string longUrl)
    {
        var shortenedUrl = new ShortenedUrl()
        {
            ShortUrl = shortUrl,
            LongUrl = longUrl
        };

        _context.ShortenedUrls.Add(shortenedUrl);
        _context.SaveChanges();
        

        return shortenedUrl;
    }
}