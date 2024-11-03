using CompanyProject.Models;

namespace CompanyProject.Repository
{
    public interface IAboutRepository
    {
        Task<IEnumerable<About>> GetAllAsync();
        Task<About> GetByIdAsync(int id);
        Task AddAsync(About about);
        Task UpdateAsync(About about);
        Task DeleteAsync(int id);
    }
}
