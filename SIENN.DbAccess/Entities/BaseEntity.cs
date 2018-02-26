using System.ComponentModel.DataAnnotations;
using SIENN.DbAccess.Interfaces;

namespace SIENN.DbAccess.Entities
{
    public class BaseEntity : IKey
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