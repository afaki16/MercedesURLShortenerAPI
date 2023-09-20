using Microsoft.EntityFrameworkCore;

namespace Mercedes.URLShorter
{

    public class ShorterDBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
        public ShorterDBContext(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
        }

    }
}
