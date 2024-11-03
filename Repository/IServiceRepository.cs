using CompanyProject.Models;
/*
namespace CompanyProject.Repository
{
    public interface IServiceRepository
    {

        Task<Service> CreateServiceAsync(Service service);

        Task<Service?> GetServiceByIdAsync(int id);
        Task<List<Service>> GetAllServicesAsync();
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);
        Task<List<Service>> GetActiveServicesAsync();

        Task<Media> CreateMediaAsync(IFormFile file, string? recordId, string? tableName, string? folderName, int? serviceId);

    }
}
*/






using CompanyProject.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyProject.Repository
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllAsync();
        Task<Service> GetByIdAsync(int id);
        Task<Service> AddAsync(Service service, IFormFile imageFile);
        Task UpdateAsync(Service service);
        Task DeleteAsync(int id);
    }
}

