using CompanyProject.Data.Migrations;
using CompanyProject.Models;
using CompanyProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using About = CompanyProject.Models.About;
/*
namespace CompanyProject.Controllers
{
    
    public class DashboardController : Controller
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IServiceRepository _serviceRepository; 
        private readonly IMediaRepository _mediaRepository;

        public DashboardController(IServiceRepository serviceRepository, IAboutRepository aboutRepository, UserManager<IdentityUser> userManager, IMediaRepository mediaRepository)
        {
            _aboutRepository = aboutRepository;
            _userManager = userManager;
            _serviceRepository= serviceRepository;
            _mediaRepository = mediaRepository;

        }*/
/*
public async Task<IActionResult> Index()
{
    var aboutEntries = await _aboutRepository.GetAllAsync();
    return View("AboutIndex",aboutEntries);
}



[HttpGet]
public async Task<IActionResult> Create()
{
    var user = await _userManager.GetUserAsync(User);
    var about = new About
    {
        UserId = user?.Id 
    };
    return View("CreateAbout", about);
}




[HttpPost]
[ValidateAntiForgeryToken]

public async Task<IActionResult> Create(About? about)
{

        var user = await _userManager.GetUserAsync(User);
        about.UserId = user.Id;
    about.IsActive = about.IsActive;
    about.IsDeleted = false;
        await _aboutRepository.AddAsync(about);
        return RedirectToAction(nameof(Index));
               // return View("CreateAbout",about);
}

public async Task<IActionResult> Edit(int id)
{
    var about = await _aboutRepository.GetByIdAsync(id);
    if (about == null) return NotFound();
    return View("EditAbout", about);
}

[HttpPost]
public async Task<IActionResult> Edit(About about)
{
    if (ModelState.IsValid)
    {
        await _aboutRepository.UpdateAsync(about);
        return RedirectToAction(nameof(Index));
    }
    return View("EditAbout", about);
}

public async Task<IActionResult> DeleteAbout(int id)
{
    var about = await _aboutRepository.GetByIdAsync(id);
    return View("DeleteAbout",about);
}

[HttpPost]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    await _aboutRepository.DeleteAsync(id);
    return RedirectToAction(nameof(Index));
}*/











/*cor

[HttpGet]
public async Task<IActionResult> CreateService()
{

    var user = await _userManager.GetUserAsync(User);
    var service =new Service
    {
        UserId = user?.Id
    };



    return View("CreateService",service);
}
*/


/*correct without userid

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> CreateService(Service model, IFormFile imageFile)
{
    if (imageFile != null && imageFile.Length > 0)
    {

        var imageGuid = Guid.NewGuid();
        var fileExtension = Path.GetExtension(imageFile.FileName);


        var fileName = imageGuid + fileExtension;
        var filePath = Path.Combine("wwwroot/images", fileName);


        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(stream);
        }


        model.ImagePath = "/images/" + fileName;
    }

    await _serviceRepository.AddAsync(model);
    return RedirectToAction("ServiceIndex");
}

*/



/*cor
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> CreateService(Service model, IFormFile imageFile)
{
    if (imageFile != null && imageFile.Length > 0)
    {
        var imageGuid = Guid.NewGuid();
        var fileExtension = Path.GetExtension(imageFile.FileName);

        var fileName = imageGuid + fileExtension;
        var filePath = Path.Combine("wwwroot/images", fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(stream);
        }

        model.ImagePath = "/images/" + fileName;
    }

    var user = await _userManager.GetUserAsync(User);
    if (user == null)
    {
        ModelState.AddModelError("", "User not found.");
        return View(model);
    }
    model.UserId = user.Id;

    await _serviceRepository.AddAsync(model);
    return RedirectToAction("ServiceIndex");
}
*/










/*
[HttpGet]
public async Task<IActionResult> EditService(int id)
{
    var about = await _serviceRepository.GetByIdAsync(id);
    if (about == null) return NotFound();
    return View("EditService", about);
}

[HttpPost]
public async Task<IActionResult> EditService(Service service)
{
    if (ModelState.IsValid)
    {
        await _serviceRepository.UpdateAsync(service);
        return RedirectToAction(nameof(Index));
    }
    return View("EditAbout", service);
}

*/




/*idk edit

[HttpGet]
public async Task<IActionResult> EditService(int id)
{
    var service = await _serviceRepository.GetByIdAsync(id);
    if (service == null) return NotFound();
    return View("EditService", service);
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> EditService(Service service, IFormFile? imageFile)
{
    if (ModelState.IsValid)
    {
        if (imageFile != null && imageFile.Length > 0)
        {
            var imageGuid = Guid.NewGuid();
            var fileExtension = Path.GetExtension(imageFile.FileName);
            var fileName = imageGuid + fileExtension;
            var filePath = Path.Combine("wwwroot/images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            service.ImagePath = "/images/" + fileName;
            service.ImageGuid = imageGuid;
        }

        await _serviceRepository.UpdateAsync(service);
        return RedirectToAction("ServiceIndex");
    }
    return View("EditService", service);
}
*/



/*

public IActionResult CreateService() { 

    return View();
}*/

// POST: Service/Create
/*
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> CreateService(Service service, IFormFile? image)
{
    if (ModelState.IsValid)
    {
        if (image != null)
        {
            var media = await _mediaRepository.CreateMediaAsync(image, service.Id.ToString(), "Service", "services");
            service.ImageGuid = media.Id;
        }

        await _serviceRepository.AddAsync(service);
        return RedirectToAction(nameof(ServiceIndex));
    }
    return View(service);
}*/





/*


[HttpPost]
public async Task<IActionResult> CreateService(Service service, IFormFile imageFile)
{
    await _serviceRepository.AddAsync(service, imageFile);
    return RedirectToAction("ServiceIndex");
}
*/



/*

[HttpPost]
public async Task<IActionResult> CreateService(Service service, IFormFile imageFile)
{


    // Add the service first and save changes to generate an ID
    await _serviceRepository.AddAsync(service);

    // Now that the service is added, we can create the media
    if (imageFile != null)
    {
        var media = await _mediaRepository.CreateMediaAsync(
            imageFile,
            service.Id.ToString(), // Use the generated Id here
            nameof(Service),
            "ServiceImages");

        service.ImageGuid = media.Id; // Set the ImageGuid
        service.ImagePath = $"/media/ServiceImages/{media.Id}{Path.GetExtension(media.Name)}"; // Set the ImagePath
        await _serviceRepository.UpdateAsync(service); // Update the service with the image information
    }

    return RedirectToAction("ServiceIndex");
}

*/



// GET: Service/Edit/5


// GET: Service/Delete/5
/*
public async Task<IActionResult> DeleteService(int id)
{
    var service = await _serviceRepository.GetByIdAsync(id);
    if (service == null) return NotFound();

    return View(service);
}

// POST: Service/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmedService(int id)
{
    var service = await _serviceRepository.GetByIdAsync(id);
    if (service == null) return NotFound();

    if (service.ImageGuid.HasValue)
    {
        await _mediaRepository.DeleteMediaAsync(service.ImageGuid.Value);
    }

    await _serviceRepository.DeleteAsync(id);
    return RedirectToAction(nameof(Index));
}*/

// GET: Service/GetMedia/5
/*
public async Task<IActionResult> GetServiceMedia(int serviceId)
{
    var mediaFiles = await _mediaRepository.GetMediaByRecordIdAsync(serviceId.ToString());
    return View(mediaFiles);
}*/










/*

namespace CompanyProject.Controllers
    {
        public class DashboardController : Controller
        {
            private readonly IServiceRepository _serviceRepository;

            public DashboardController(IServiceRepository serviceRepository)
            {
                _serviceRepository = serviceRepository;
            }

            public async Task<IActionResult> ServiceIndex()
            {
                List<Service> services = await _serviceRepository.GetAllServicesAsync();
                return View(services);
            }

            public IActionResult CreateService()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> CreateService(Service service)
            {
                if (ModelState.IsValid)
                {
                    await _serviceRepository.CreateServiceAsync(service);
                    return RedirectToAction(nameof(Index));
                }
                return View(service);
            }


            









        }
    }

*/





using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompanyProject.Models;
using CompanyProject.Repository;

namespace CompanyProject.Controllers
{
    public class DashboardController :Controller
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public DashboardController(IServiceRepository serviceRepository, IMediaRepository mediaRepository, UserManager<IdentityUser> userManager)
        {
            _serviceRepository = serviceRepository;
            _mediaRepository = mediaRepository;
            _userManager= userManager;
        }

       







        public async Task<IActionResult> ServiceIndex()
        {
            var services = await _serviceRepository.GetAllAsync();
            var serviceWithMedia = new List<(Service service, Media? media)>();

            foreach (var service in services)
            {
                Media? media = null;
                if (service.ImageGuid.HasValue)
                {
                    media = await _mediaRepository.GetMediaByGuidAsync(service.ImageGuid.Value);
                }
                serviceWithMedia.Add((service, media));
            }

            return View(serviceWithMedia);
        }








  

        [HttpGet]
        public async Task<IActionResult> CreateService()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var service = new Service
            {
                UserId = user.Id 
            };

            return View("CreateService", service);
            //return View("CreateService");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateService(Service service, IFormFile imageFile)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            service.UserId = user.Id;

            await _serviceRepository.AddAsync(service, imageFile);

            return RedirectToAction(nameof(ServiceIndex));
        }


















        [HttpGet]
        public async Task<IActionResult> EditService(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }



       

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditService(Service service, IFormFile? imageFile)
        {
            var user = await _userManager.GetUserAsync(User);

           // service.UserId = user?.Id;
            if (ModelState.IsValid)
            {
                var existingService = await _serviceRepository.GetByIdAsync(service.Id);
                if (existingService == null)
                {
                    return NotFound();
                }

                existingService.Title = service.Title;
                existingService.Description = service.Description;
                existingService.IsActive = service.IsActive;
                existingService.IsDeleted = service.IsDeleted;
               // existingService.UserId = user?.Id;

                if (imageFile != null && imageFile.Length > 0)
                {
                    if (existingService.ImageGuid.HasValue)
                    {
                        await _mediaRepository.DeleteMediaAsync(existingService.ImageGuid.Value);
                    }

                    var media = await _mediaRepository.CreateMediaAsync(
                        imageFile,
                        existingService.Id.ToString(),
                        nameof(Service),
                        "ServiceImages");

                    existingService.ImageGuid = media.Id; 
                }

                await _serviceRepository.UpdateAsync(existingService);
                return RedirectToAction(nameof(ServiceIndex));
            }

            return View(service);
        }







        [HttpPost, ActionName("DeleteService")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteServiceConfirmed(int id)
        {
            await _serviceRepository.DeleteAsync(id);
            return RedirectToAction(nameof(ServiceIndex));
        }





    }



    
  


}































