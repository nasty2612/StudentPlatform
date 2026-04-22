using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPlatform.Domain.Entities;

namespace StudentPlatform.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> ServiceCategoriesEdit(int id)
        {
            // В зависимости от наличи ID либо добавляем, либо изменяем ID
            ServiceCategory? entity = id == default 
                ? new ServiceCategory() 
                : await _dataManager.ServiceCategories.GetServiceCategoryByIdAsync(id);
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesEdit(ServiceCategory entity)
        {
            //  В модели присутствуют ошибкЮ возвращаем на доработку
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            await _dataManager.ServiceCategories.SaveServiceCategoryAsync(entity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesDelete (int id)
        {
            await _dataManager.ServiceCategories.DeleteServiceCategoryAsync(id);
            return RedirectToAction("Index");
        }
    }
}
