using CompanyProject.Data;
using CompanyProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository
{
    public class NewsRepository:INewsRepository
    {


        private readonly ApplicationDbContext _context;
        private readonly IMediaRepository _mediaRepository;

        public NewsRepository(ApplicationDbContext context, IMediaRepository mediaRepository)
        {
            _context = context;
            _mediaRepository = mediaRepository;
        }

        public async Task<IEnumerable<News>> GetAllAsync()
        {

            return await _context.News.ToListAsync();

        }

        public async Task<News> GetByIdAsync(int id)
        {
            return await _context.News.FindAsync(id);
        }

        public async Task<News> AddAsync(News news, IFormFile imageFile)
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();

            if (imageFile != null)
            {
                var media = await _mediaRepository.CreateMediaAsync(
                    imageFile,
                    news.Id.ToString(),
                    nameof(News),
                    "NewsImages");

                news.ImageGuid = media.Id;
                await UpdateAsync(news);
            }

            return news;
        }

        public async Task UpdateAsync(News news)
        {
            _context.News.Update(news);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var news = await GetByIdAsync(id);
            if (news!= null)
            {
                news.IsDeleted = true;
                await UpdateAsync(news);
            }
        }



    }
}
