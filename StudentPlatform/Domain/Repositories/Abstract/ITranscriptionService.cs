namespace StudentPlatform.Domain.Repositories.Abstract
{
    public interface ITranscriptionService
    {
        // Метод принимает поток файла и возвращает путь к готовому тексту
        Task<string> TranscribeAsync(IFormFile audioFile);
    }
}