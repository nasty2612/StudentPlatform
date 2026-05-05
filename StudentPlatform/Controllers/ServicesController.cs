using Microsoft.AspNetCore.Mvc;
using StudentPlatform.Domain;
using StudentPlatform.Domain.Entities;
using StudentPlatform.Infrastructure;
using StudentPlatform.Models;

namespace StudentPlatform.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataManager _dataManager;
        public ServicesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Service> list = await _dataManager.Services.GetServicesAsync();
            // DTO вместо доменной сущности
            IEnumerable<ServiceDTO> listDTO = HelperDTO.TransformServices(list);
            return View(listDTO);
        }
        public async Task<IActionResult> Show(int id)
        {
            Service? entity = await _dataManager.Services.GetServiceByIdAsync(id);
            // ошибка 404
            if (entity is null)
            {
                return NotFound();
            }
            ServiceDTO entityDTO = HelperDTO.TransformService(entity);
            return View(entityDTO);
        }
    }
}
