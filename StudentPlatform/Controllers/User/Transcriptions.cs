using Microsoft.AspNetCore.Mvc;
using StudentPlatform.Domain.Entities;

namespace StudentPlatform.Controllers.User
{
    public partial class UserController
    {
        [HttpPost]
        public async Task<IActionResult> TranscribeAudio(IFormFile audioFile)
        {
            if (audioFile == null || audioFile.Length == 0) return RedirectToAction("Index");

            var userId = _userManager.GetUserId(User);

            // 1. Сохраняем аудио
            string audioFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/audio/");
            if (!Directory.Exists(audioFolder)) Directory.CreateDirectory(audioFolder);

            string audioPath = Path.Combine(audioFolder, audioFile.FileName);
            using (var stream = new FileStream(audioPath, FileMode.Create))
            {
                await audioFile.CopyToAsync(stream);
            }

            // 2. Место для Whisper (имитация создания файла)
            string fileName = $"transcription_{Guid.NewGuid()}.txt";
            string txtFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/txt/");
            if (!Directory.Exists(txtFolder)) Directory.CreateDirectory(txtFolder);

            string txtPath = Path.Combine(txtFolder, fileName);
            await System.IO.File.WriteAllTextAsync(txtPath, "Здесь будет результат работы Whisper AI...");

            // 3. Запись в БД (чтобы файл отобразился в списке для скачивания)
            // transcription.UserId = userId; 
            // transcription.TextFilePath = fileName;

            return RedirectToAction("Index");
        }

        // Скачивание результата
        public IActionResult DownloadTranscription(string fileName)
        {
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/txt/", fileName);
            if (!System.IO.File.Exists(path)) return NotFound();

            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, "text/plain", fileName);
        }
    }
}


