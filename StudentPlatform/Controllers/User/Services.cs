using Microsoft.AspNetCore.Mvc;
using StudentPlatform.Domain.Entities;

namespace StudentPlatform.Controllers.User
{
    public partial class UserController
    {
        public async Task<IActionResult> ServicesEdit(int id)
        {
            var userId = _userManager.GetUserId(User);
            Service? entity;

            if (id == default)
            {
                entity = new Service { UserId = userId };
            }
            else
            {
                entity = await _dataManager.Services.GetServiceByIdAsync(id);
                // Защита: если пост не твой — доступ запрещен
                if (entity?.UserId != userId) return Forbid();
            }

            ViewBag.ServiceCategories = await _dataManager.ServiceCategories.GetServiceCategoriesAsync();
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ServicesEdit(Service entity, IFormFile? titleImageFile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ServiceCategories = await _dataManager.ServiceCategories.GetServiceCategoriesAsync();
                return View(entity);
            }

            // Принудительно привязываем к текущему юзеру
            entity.UserId = _userManager.GetUserId(User);

            if (titleImageFile != null)
            {
                entity.Photo = titleImageFile.FileName;
                await SaveImg(titleImageFile);
            }

            await _dataManager.Services.SaveServiceAsync(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ServicesDelete(int id)
        {
            var userId = _userManager.GetUserId(User);
            var entity = await _dataManager.Services.GetServiceByIdAsync(id);

            if (entity?.UserId != userId) return Forbid();

            await _dataManager.Services.DeleteServiceAsync(id);
            return RedirectToAction("Index");
        }
    }
}
