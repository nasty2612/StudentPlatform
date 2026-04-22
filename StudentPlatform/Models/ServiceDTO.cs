namespace StudentPlatform.Models
{
    public class ServiceDTO
    {
        // Свойства, который будет видеть пользователь
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? Title { get; set; }
        public string? DescriptionShort { get; set; }
        public string? Description { get; set; }
        public string? PhoneFileName { get; set; }
        public string? Type { get; set; }
    }
}
