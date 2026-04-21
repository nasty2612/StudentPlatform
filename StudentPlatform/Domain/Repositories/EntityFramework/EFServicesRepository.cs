using Microsoft.EntityFrameworkCore;
using StudentPlatform.Domain.Entities;
using StudentPlatform.Domain.Repositories.Abstract;

namespace StudentPlatform.Domain.Repositories.EntityFramework
{
    public class EFServicesRepository : IServicesRepository
    {
        private readonly AppDbContext _context;
        public EFServicesRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Service>> GetServicesAsync()
        { // Странная фигня, почему-то с маленькой ServiceCategory не тся, а с большой наоборот
            return await _context.Services.Include(x => x.serviceCategory).ToListAsync();
        }
        public async Task<Service?> GetServiceByIdAsync(int id)
        {
            return await _context.Services.Include(x => x.serviceCategory).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task SaveServiceAsync(Service entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteServiceAsync(int id)
        {
            _context.Entry(new Service() { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
