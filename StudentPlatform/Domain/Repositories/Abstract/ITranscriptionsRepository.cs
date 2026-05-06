using StudentPlatform.Domain.Entities;
using StudentPlatform.Domain.Entities.StudentPlatform.Domain.Entities;
using StudentPlatform.Domain.Repositories.Abstract;
using StudentPlatform.Domain.Repositories.EntityFramework;

namespace StudentPlatform.Domain.Repositories.Abstract
{
    public interface ITranscriptionsRepository
    {
        Task<IEnumerable<Transcription>> GetTranscriptionsByUserIdAsync(string userId);
        Task SaveTranscriptionAsync(Transcription entity);
        Task<Transcription?> GetTranscriptionByIdAsync(int id);
        Task DeleteTranscriptionAsync(int id);
    }
}