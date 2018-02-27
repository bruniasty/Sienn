using System.ComponentModel.DataAnnotations;

namespace SIENN.DbAccess.DTO
{
    public class BaseDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Code { get; set; }

        [MaxLength(1023)]
        public string Description { get; set; }
    }
}