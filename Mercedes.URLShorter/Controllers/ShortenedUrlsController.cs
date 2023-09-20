using Mercedes.URLShorter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mercedes.URLShorter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortenedUrlsController : ControllerBase
    {
        private readonly ShortenedUrlRepository _shortenedUrlRepository;

        public ShortenedUrlsController(ShortenedUrlRepository shortenedUrlRepository)
        {
            _shortenedUrlRepository = shortenedUrlRepository;
        }

       
        [HttpPost("shorten")]
        public IActionResult Shorten(UrlShortInput input)
        {
            
            if (_shortenedUrlRepository.ExistLongUrl(input.LongUrl))
            {
                return Conflict(new ResultDto<string>()
                {
                    IsSuccess = false,
                    Error = "This record is already exist"
                });

            }

            if (!Uri.IsWellFormedUriString(input.LongUrl, UriKind.Absolute))
            {
               
                return BadRequest(new ResultDto<string>()
                {
                    IsSuccess = false,
                    Error = "Invalid Url Format"
                });
            }
            
            var shortUrl = Guid.NewGuid().ToString().Substring(0, 6);

            
            _shortenedUrlRepository.AddShortenedUrl(shortUrl, input.LongUrl);

            return Ok(new ResultDto<string>()
            {
                IsSuccess = true,
                Response = shortUrl
            }); 
        }

        [HttpPost("shorten/custom")]
        public IActionResult CustomUrl(UrlShortCustomInput input)
        {
            if (_shortenedUrlRepository.ExistShortUrl(input.ShortUrl) || _shortenedUrlRepository.ExistLongUrl(input.LongUrl))
            {
                return Conflict(new ResultDto<string>()
                {
                    IsSuccess = false,
                    Error = "This record is already exist"
                });

            }


            if (!Uri.IsWellFormedUriString(input.LongUrl, UriKind.Absolute))
            {
                return BadRequest(new ResultDto<string>()
                {
                    IsSuccess = false,
                    Error = "Invalid Url Format"
                });

            }
            
            _shortenedUrlRepository.AddShortenedUrl(input.ShortUrl, input.LongUrl);


            return Ok(new ResultDto<string>()
            {
                IsSuccess = true,
                Response = input.ShortUrl
            });
        }


       
        [HttpGet("redirect/{shortUrl}")]
        public IActionResult Redirect(string shortUrl)
        {
            var shortenedUrl = _shortenedUrlRepository.GetShortenedUrl(shortUrl);
            if (shortenedUrl == null)
            {
                return NotFound();
            }

            
            return RedirectPermanent(shortenedUrl.LongUrl);
        }
    }
}
