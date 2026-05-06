using Microsoft.AspNetCore.Http;
using StudentPlatform.Domain.Repositories.Abstract;
using System;
using System.IO;
using System.Threading.Tasks;

namespace StudentPlatform.Domain.Services
{
    public class TranscriptionService : ITranscriptionService
    {
        private readonly string _storagePath;

        public TranscriptionService(string webRootPath)
        {
            // Путь, где будут лежать результаты
            _storagePath = Path.Combine(webRootPath, "uploads", "transcriptions");
            if (!Directory.Exists(_storagePath)) Directory.CreateDirectory(_storagePath);
        }

        public async Task<string> TranscribeAsync(IFormFile audioFile)
        {
            // Генерируем уникальное имя для текстового файла
            string fileName = $"{Guid.NewGuid()}.txt";
            string fullPath = Path.Combine(_storagePath, fileName);

            // Сейчас просто пишем заглушку в файл
            string dummyText = $"Это расшифровка файла {audioFile.FileName}.\nВремя обработки: {DateTime.Now}";
            await File.WriteAllTextAsync(fullPath, dummyText);

            // Возвращаем только имя файла для записи в БД
            return fileName;
        }
    }
}