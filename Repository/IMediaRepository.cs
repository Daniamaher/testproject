using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyProject.Models;
/*
namespace CompanyProject.Repository
{
    public interface IMediaRepository
    {
        Task<Media> CreateMediaAsync(IFormFile file, string? recordId, string? tableName, string? folderName);
        Task<Media?> GetMediaAsync(Guid id);
        Task DeleteMediaAsync(Guid id);
    }
}
*/




using CompanyProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyProject.Repository
{
    public interface IMediaRepository
    {
        Task<Media> CreateMediaAsync(IFormFile file, string? recordId, string? tableName, string? folderName);
        Task<Media?> GetMediaByGuidAsync(Guid id);
        Task<List<Media>> GetMediaByRecordIdAsync(string recordId);
        Task DeleteMediaAsync(Guid id);
    }
}
