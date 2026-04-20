namespace StudentPlatform.Infrastructure
{
    public class AppConfig
    {
        public TinyMCE TinyMCE { get; set; } = new TinyMCE();
        public StudentPlatform StudentPlatform { get; set; } = new StudentPlatform();
        public Database Database { get; set; } = new Database();
    }

    public class Database
    {
        public string? ConnectionString { get; set; }
    }

    public class TinyMCE
    {
        public string? APIKey { get; set; }
    }

    public class StudentPlatform
    {
        public string? Name { get; set; }
        public string? Help { get; set; }
    }
}
