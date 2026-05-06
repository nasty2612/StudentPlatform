using Microsoft.AspNetCore.Mvc;
using StudentPlatform.Domain.Entities;
using System.Runtime.InteropServices;

namespace StudentPlatform.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> ServicesEdit(int id)
        {
            // В зависимости от id либо добавляем, либо изменяем id
            Service? entity = id == default ? new Service() { UserId = _userManager.GetUserId(User)} : await _dataManager.Services.GetServiceByIdAsync(id);
            ViewBag.ServiceCategories = await _dataManager.ServiceCategories.GetServiceCategoriesAsync();
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> ServicesEdit(Service entity, IFormFile? titleImageFile)
        {
            // в случае ошибки отправляем на доработку
            if (!ModelState.IsValid)
            {
                ViewBag.ServiceCategories = await _dataManager.ServiceCategories.GetServiceCategoriesAsync();
                return View(entity);
            }
            if (titleImageFile != null)
            {
                entity.Photo = titleImageFile.FileName;
                await SaveImg(titleImageFile);
            }
            await _dataManager.Services.SaveServiceAsync(entity);
            _logger.LogInformation($"Добавлен/обновлен новый пост с ID: {entity.Id}");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> ServicesDelete(int id)
        {
            await _dataManager.Services.DeleteServiceAsync(id);
            _logger.LogInformation($"Удален пост с ID: {id}");
            return RedirectToAction("Index");
        }
    }
}
