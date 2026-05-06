namespace StudentPlatform.Domain.Entities
{
    using System;

    namespace StudentPlatform.Domain.Entities
    {
        public class Transcription
        {
            public int Id { get; set; }
            public string UserId { get; set; } = string.Empty; // Кто загрузил
            public string AudioFileName { get; set; } = string.Empty; // Имя исх. файла
            public string TextFileName { get; set; } = string.Empty; // Имя .txt файла
            public DateTime CreatedAt { get; set; } = DateTime.Now;
        }
    }
}
