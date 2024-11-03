
/*
namespace CompanyProject.Repository
{
    public class ServiceRepository: IServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            //return await _context.About.Where(a => !a.IsDeleted).ToListAsync();
            return await _context.Service.ToListAsync();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _context.Service.FindAsync(id);
        }

        public async Task AddAsync(Service service)
        {
            _context.Service.Add(service);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(Service service)
        {
            _context.Service.Update(service);
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
*/














/*




using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyProject.Data;
using CompanyProject.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CompanyProject.Data;
using CompanyProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly string _baseFolder;

        public ServiceRepository(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _baseFolder = Path.Combine(environment.WebRootPath, "media");
        }

        public async Task<Service> CreateServiceAsync(Service service)
        {
            _context.Service.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }



        public async Task<Media> CreateMediaAsync(IFormFile file, string? recordId, string? tableName, string? folderName, int? serviceId)
        {
            var media = new Media
            {
                Id = Guid.NewGuid(),
                RecordId = recordId,
                TableName = tableName,
                Name = file.FileName,
                Type = Path.GetExtension(file.FileName),
                IsActive = true,
                ServiceId = serviceId
            };

            var folderPath = Path.Combine(_baseFolder, folderName ?? "uploads");
            Directory.CreateDirectory(folderPath);

            try
            {
                var filePath = Path.Combine(folderPath, $"{media.Id}{media.Type}");
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while saving the file.", ex);
            }

            _context.Media.Add(media);
            await _context.SaveChangesAsync();

            return media;
        }

        public async Task<Service?> GetServiceByIdAsync(int id)
        {
            return await _context.Service.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task<List<Service>> GetAllServicesAsync()
        {
            return await _context.Service.Where(s => !s.IsDeleted).ToListAsync();
        }

        public async Task UpdateServiceAsync(Service service)
        {
            _context.Service.Update(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _context.Service.FindAsync(id);
            if (service != null)
            {
                service.IsDeleted = true;
                _context.Service.Update(service);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Service>> GetActiveServicesAsync()
        {
            return await _context.Service.Where(s => s.IsActive && !s.IsDeleted).ToListAsync();
        }
    }
}
*/








/*
using CompanyProject.Data;
using CompanyProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyProject.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediaRepository _mediaRepository;

        public ServiceRepository(ApplicationDbContext context, IMediaRepository mediaRepository)
        {
            _context = context;
            _mediaRepository = mediaRepository;
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await _context.Service.Where(s => !s.IsDeleted).ToListAsync();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _context.Service.FindAsync(id);
        }

        public async Task<Service> AddAsync(Service service, IFormFile imageFile)
        {
            _context.Service.Add(service);
            await _context.SaveChangesAsync();

            if (imageFile != null)
            {
                var media = await _mediaRepository.CreateMediaAsync(
                    imageFile,
                    service.Id.ToString(),
                    nameof(Service),
                    "ServiceImages");

                service.ImageGuid = media.Id;
                await UpdateAsync(service);
            }

            return service;
        }

        public async Task UpdateAsync(Service service)
        {
            _context.Service.Update(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var service = await GetByIdAsync(id);
            if (service != null)
            {
                service.IsDeleted = true;
                await UpdateAsync(service);
            }
        }
    }
}
*/


















using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyProject.Data;
using CompanyProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediaRepository _mediaRepository;

        public ServiceRepository(ApplicationDbContext context, IMediaRepository mediaRepository)
        {
            _context = context;
            _mediaRepository = mediaRepository;
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            //return await _context.Service.Where(s => !s.IsDeleted).ToListAsync();

            return await _context.Service.ToListAsync();

        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _context.Service.FindAsync(id);
        }

        public async Task<Service> AddAsync(Service service, IFormFile imageFile)
        {
            _context.Service.Add(service);
            await _context.SaveChangesAsync();

            if (imageFile != null)
            {
                var media = await _mediaRepository.CreateMediaAsync(
                    imageFile,
                    service.Id.ToString(),
                    nameof(Service),
                    "ServiceImages");

                service.ImageGuid = media.Id;
                await UpdateAsync(service);
            }

            return service;
        }

        public async Task UpdateAsync(Service service)
        {
            _context.Service.Update(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var service = await GetByIdAsync(id);
            if (service != null)
            {
                service.IsDeleted = true;
                await UpdateAsync(service);
            }
        }
    }
}
