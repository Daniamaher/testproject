using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CompanyProject.Data;
using CompanyProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
/*
namespace CompanyProject.Repository
{
    public class MediaRepository : IMediaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly string _baseFolder;

        public MediaRepository(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _baseFolder = Path.Combine(environment.WebRootPath, "media");
        }

        public async Task<Media> CreateMediaAsync(IFormFile file, string? recordId, string? tableName, string? folderName)
        {
            var media = new Media
            {
                Id = Guid.NewGuid(),
                RecordId = recordId,
                TableName = tableName,
                Name = file.FileName,
                Type = Path.GetExtension(file.FileName),
                IsActive = true
            };

            // Ensure the media folder exists
            var folderPath = Path.Combine(_baseFolder, folderName ?? "uploads");
            Directory.CreateDirectory(folderPath);

            // Save the file to the folder
            var filePath = Path.Combine(folderPath, $"{media.Id}{media.Type}");
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Add and save the media to the database
            _context.Media.Add(media);
            await _context.SaveChangesAsync();

            return media;
        }

        public async Task<Media?> GetMediaByGuidAsync(Guid id)
        {
            return await _context.Media.FindAsync(id);
        }

        public async Task<List<Media>> GetMediaByRecordIdAsync(string recordId)
        {
            return await _context.Media
                                 .Where(m => m.RecordId == recordId)
                                 .ToListAsync();
        }

        public async Task DeleteMediaAsync(Guid id)
        {
            var media = await _context.Media.FindAsync(id);
            if (media != null)
            {
                _context.Media.Remove(media);
                await _context.SaveChangesAsync();
            }
        }
    }
}
*/






/*

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CompanyProject.Models;

namespace CompanyProject.Services
{
    public class MediaService
    {
        private readonly string _baseFolder;
        private readonly ApplicationDbContext _context;

        public MediaService(string baseFolder, ApplicationDbContext context)
        {
            _baseFolder = baseFolder;
            _context = context;
        }

        public async Task<Media> CreateMediaAsync(IFormFile file, string? recordId, string? tableName, string? folderName)
        {
            var media = new Media
            {
                Id = Guid.NewGuid(),
                RecordId = recordId,
                TableName = tableName,
                Name = file.FileName,
                Type = Path.GetExtension(file.FileName),
                IsActive = true
            };

            var folderPath = Path.Combine(_baseFolder, folderName ?? "uploads");
            Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, $"{media.Id}{media.Type}");
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            _context.Media.Add(media);
            await _context.SaveChangesAsync();

            return media;
        }
    }
}
*/



















// Repository/MediaRepository.cs





/*
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CompanyProject.Data;
using CompanyProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;

namespace CompanyProject.Repository
{
    public class MediaRepository : IMediaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly string _baseFolder;

        public MediaRepository(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _baseFolder = Path.Combine(environment.WebRootPath, "media");
        }
        /*
        public async Task<Media> CreateMediaAsync(IFormFile file, string? recordId, string? tableName, string? folderName)
        {
            var media = new Media
            {
                Id = Guid.NewGuid(),
                RecordId = recordId,
                TableName = tableName,
                Name = file.FileName,
                Type = Path.GetExtension(file.FileName),
                IsActive = true
            };

            var folderPath = Path.Combine(_baseFolder, folderName ?? "uploads");
            Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, $"{media.Id}{media.Type}");
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            _context.Media.Add(media);
            await _context.SaveChangesAsync();

            return media;
        }*/










/*
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
using Microsoft.Extensions.Logging;

namespace CompanyProject.Repository
{
    public class MediaRepository : IMediaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly string _baseFolder;
        private readonly ILogger<MediaRepository> _logger;

        public MediaRepository(ApplicationDbContext context, IWebHostEnvironment environment, ILogger<MediaRepository> logger)
        {
            _context = context;
            _baseFolder = Path.Combine(environment.WebRootPath, "media");
            _logger = logger;
        }

        public async Task<Media> CreateMediaAsync(IFormFile file, string? recordId, string? tableName, string? folderName)
        {
            try
            {
                var media = new Media
                {
                    Id = Guid.NewGuid(),
                    RecordId = recordId,
                    TableName = tableName,
                    Name = file.FileName,
                    Type = Path.GetExtension(file.FileName),
                    IsActive = true
                };

                // Ensure the media folder exists
                var folderPath = Path.Combine(_baseFolder, folderName ?? "uploads");
                Directory.CreateDirectory(folderPath);

                // Save the file to the folder
                var filePath = Path.Combine(folderPath, $"{media.Id}{media.Type}");
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Log before saving to the database
                _logger.LogInformation("Saving media to database: {MediaId}", media.Id);

                // Add and save the media to the database
                _context.Media.Add(media);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Media saved successfully with ID: {MediaId}", media.Id);

                return media;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while saving media");
                throw;  
            }
        }

        public async Task<Media?> GetMediaByGuidAsync(Guid id)
        {
            return await _context.Media.FindAsync(id);
        }

        public async Task<List<Media>> GetMediaByRecordIdAsync(string recordId)
        {
            return await _context.Media
                                 .Where(m => m.RecordId == recordId)
                                 .ToListAsync();
        }

        public async Task DeleteMediaAsync(Guid id)
        {
            var media = await _context.Media.FindAsync(id);
            if (media != null)
            {
                _context.Media.Remove(media);
                await _context.SaveChangesAsync();
            }
        }

        Task<Media> IMediaRepository.CreateMediaAsync(IFormFile file, string? recordId, string? tableName, string? folderName)
        {
            throw new NotImplementedException();
        }

        Task<Media?> IMediaRepository.GetMediaAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task IMediaRepository.DeleteMediaAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
*/










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
    public class MediaRepository : IMediaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly string _baseFolder;

        public MediaRepository(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _baseFolder = Path.Combine(environment.WebRootPath, "media");
        }

        public async Task<Media> CreateMediaAsync(IFormFile file, string? recordId, string? tableName, string? folderName)
        {
            var media = new Media
            {
                Id = Guid.NewGuid(),
                RecordId = recordId,
                TableName = tableName,
                Name = file.FileName,
                Type = Path.GetExtension(file.FileName),
                IsActive = true
            };

            var folderPath = Path.Combine(_baseFolder, folderName ?? "uploads");
            Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, $"{media.Id}{media.Type}");
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            _context.Media.Add(media);
            await _context.SaveChangesAsync();

            return media;
        }

        public async Task<Media?> GetMediaByGuidAsync(Guid id)
        {
            return await _context.Media.FindAsync(id);
        }

        public async Task<List<Media>> GetMediaByRecordIdAsync(string recordId)
        {
            return await _context.Media.Where(m => m.RecordId == recordId).ToListAsync();
        }

        public async Task DeleteMediaAsync(Guid id)
        {
            var media = await _context.Media.FindAsync(id);
            if (media != null)
            {
                _context.Media.Remove(media);
                await _context.SaveChangesAsync();
            }
        }
    }
}
