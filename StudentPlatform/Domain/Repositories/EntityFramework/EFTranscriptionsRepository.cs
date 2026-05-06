using Microsoft.EntityFrameworkCore;
using StudentPlatform.Domain.Entities;
using StudentPlatform.Domain.Entities.StudentPlatform.Domain.Entities;
using StudentPlatform.Domain.Repositories.Abstract;

namespace StudentPlatform.Domain.Repositories.EntityFramework
{
    public class EFTranscriptionsRepository : ITranscriptionsRepository
    {
        private readonly AppDbContext _context;
        public EFTranscriptionsRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Transcription>> GetTranscriptionsByUserIdAsync(string userId)
        {
            return await _context.Transcriptions
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task SaveTranscriptionAsync(Transcription entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Transcription?> GetTranscriptionByIdAsync(int id) =>
            await _context.Transcriptions.FirstOrDefaultAsync(x => x.Id == id);

        public async Task DeleteTranscriptionAsync(int id)
        {
            _context.Entry(new Transcription { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}