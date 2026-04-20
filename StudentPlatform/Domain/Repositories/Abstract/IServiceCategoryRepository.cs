using StudentPlatform.Domain.Entities;

namespace StudentPlatform.Domain.Repositories.Abstract
{
    public interface IServiceCategoryRepository
    {
        Task<IEnumerable<ServiceCategory>> GetServiceCategoriesAsync();
        Task<ServiceCategory?> GetServiceCategoryByIdAsync(int id);
        Task SaveServiceCategoryAsync(ServiceCategory entity);
        Task DeleteServiceCategoryAsync(int id);
}
