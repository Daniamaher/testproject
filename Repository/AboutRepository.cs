using CompanyProject.Data;
using CompanyProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository
{
    public class AboutRepository : IAboutRepository
    {


        private readonly ApplicationDbContext _context;

        public AboutRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<About>> GetAllAsync()
        {
            //return await _context.About.Where(a => !a.IsDeleted).ToListAsync();
            return await _context.About.ToListAsync();
        }

        public async Task<About> GetByIdAsync(int id)
        {
            return await _context.About.FindAsync(id);
        }

        public async Task AddAsync(About about)
        {
            _context.About.Add(about);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(About about)
        {
            _context.About.Update(about);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var about = await GetByIdAsync(id);
            if (about != null)
            {
                about.IsDeleted = true;
                await UpdateAsync(about);
            }
        }
    }
}