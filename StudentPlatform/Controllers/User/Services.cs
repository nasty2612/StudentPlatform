using Microsoft.AspNetCore.Mvc;
using StudentPlatform.Domain.Entities;

namespace StudentPlatform.Controllers.User
{
    public partial class UserController
    {
        public async Task<IActionResult> ServicesEdit(int id)
        {
            var userId = _userManager.GetUserId(User);
            // Если ID новый — создаем пустой объект с привязкой к юзеру, иначе ищем в базе
            Service? entity = id == default
                ? new Service { UserId = userId }
                : await _dataManager.Services.GetServiceByIdAsync(id);

            // Если юзер пытается зайти в чужой ID через адресную строку — отбиваем
            if (id != default && entity?.UserId != userId) return Forbid();

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

            // Гарантируем, что UserId не подменен
            entity.UserId = _userManager.GetUserId(User);

            if (titleImageFile != null)
            {
                entity.Photo = titleImageFile.FileName;
                await SaveImg(titleImageFile);
            }

            await _dataManager.Services.SaveServiceAsync(entity);
            _logger.LogInformation($"Пользователь {entity.UserId} обновил пост {entity.Id}");
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

