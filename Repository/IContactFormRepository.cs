using CompanyProject.Models;

namespace CompanyProject.Repository
{
    public interface IContactFormRepository
    {


        Task<IEnumerable<ContactForm>> GetAllAsync();
        Task<ContactForm> GetByIdAsync(int id);
        Task<ContactForm> AddAsync(ContactForm contactForm);
        Task UpdateAsync(ContactForm contactForm);
        Task DeleteAsync(int id);

    }
}
