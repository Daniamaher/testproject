using CompanyProject.Data;
using CompanyProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository
{
    public class ContactFormRepository:IContactFormRepository
    {




        private readonly ApplicationDbContext _context;
        private readonly IMediaRepository _mediaRepository;

        public ContactFormRepository(ApplicationDbContext context, IMediaRepository mediaRepository)
        {
            _context = context;
            _mediaRepository = mediaRepository;
        }

        public async Task<IEnumerable<ContactForm>> GetAllAsync()
        {
            //return await _context.Service.Where(s => !s.IsDeleted).ToListAsync();

            return await _context.ContactForm.ToListAsync();

        }

        public async Task<ContactForm> GetByIdAsync(int id)
        {
            return await _context.ContactForm.FindAsync(id);
        }

        public async Task<ContactForm> AddAsync(ContactForm contactForm)
        {
            _context.ContactForm.Add(contactForm);
            await _context.SaveChangesAsync();



            return contactForm;
        }

        public async Task UpdateAsync(ContactForm contactForm)
        {
            _context.ContactForm.Update(contactForm);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contactForm = await GetByIdAsync(id);
            if (contactForm != null)
            {
                contactForm.IsDeleted = true;
                await UpdateAsync(contactForm);
            }
        }




    }
}
