using CompanyProject.Models;

namespace CompanyProject.Repository
{
    public interface INewsRepository
    {


        Task<IEnumerable<News>> GetAllAsync();
        Task<News> GetByIdAsync(int id);
        Task<News> AddAsync(News news, IFormFile imageFile);
        Task UpdateAsync(News news);
        Task DeleteAsync(int id);

        

    }
}
