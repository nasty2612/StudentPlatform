using Microsoft.EntityFrameworkCore;
using StudentPlatform.Domain.Entities;
using StudentPlatform.Domain.Repositories.Abstract;

namespace StudentPlatform.Domain.Repositories.EntityFramework
{
    public class EFServiceCategoriesRepository : IServiceCategoryRepository
    {
        private readonly AppDbContext _context;
        public EFServiceCategoriesRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ServiceCategory>> GetServiceCategoriesAsync()
        {
            return await _context.ServiceCategories.Include(x=>x.Services).ToListAsync();
        }
        public async Task<ServiceCategory?> GetServiceCategoryByIdAsync(int id)
        {
            return await _context.ServiceCategories.Include(x => x.Services).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
