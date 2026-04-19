using StudentPlatform.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace StudentPlatform.Domain.Entities
{
    public class Service : EntityBase
    {
        [Display(Name = "Выберите категорию")]
        public int? ServiceCategoryId { get; set; }
        public ServiceCategory? serviceCategory { get; set; }

        [Display(Name = "Карткое описание")]
        [MaxLength(3_000)]
        public string? DescriptionShort { get; set; }

        [Display(Name = "Описание")]
        [MaxLength(100_000)]
        public string? Description { get; set; }

        [Display(Name = "Титульная картинка")]
        [MaxLength(300)]
        public string? Photo { get; set; }

        [Display(Name = "Тип поста")]
        public ServiceTypeEnum Type { get; set; }
    }
}
