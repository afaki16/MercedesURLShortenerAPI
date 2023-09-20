# Mercedes URL Shortener API

The Mercedes URL Shortener API is a web service that allows users to shorten long URLs and redirect to the original URLs using short, custom, or auto-generated short URLs. This API is built using ASP.NET Core and is designed to provide a simple and efficient URL shortening service.






### Prerequisites

Before you begin, ensure you have met the following requirements:

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
- A database setup for storing shortened URLs (configured in `appsettings.json` or `appsettings.Development.json`).

### Installation


    git clone https://github.com/your-username/mercedes-url-shortener.git
   
### Endpoints


    
    POST /api/shortenedurls/shorten{longUrl}: Shorten a URL.
    POST /api/shortenedurls/shorten/custom{longUrl,shortUrl}: Create a custom short URL.
    GET /api/shortenedurls/redirect/{shortUrl}: Redirect to a shortened URL.
    
### Example


```shell
Example - 1
{
  "LongUrl": "https://www.example.com/your-long-url-here"
}
Example - 2
{
  "ShortUrl": "abc123",
  "LongUrl": "https://www.example.com/your-long-url-here"
}
