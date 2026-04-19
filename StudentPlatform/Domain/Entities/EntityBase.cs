using System.ComponentModel.DataAnnotations;
using System.Data;

namespace StudentPlatform.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните название")]
        [Display(Name = "Название")]
        [MaxLength(200)]
        public string? Title { get; set; }

        public DateTime DataCreated { get; set; } = DateTime.UtcNow;
    }
}
