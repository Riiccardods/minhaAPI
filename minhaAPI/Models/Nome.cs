using System.ComponentModel.DataAnnotations;

namespace minhaAPI.Models
{
    public class Nome
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeCompleto { get; set; }
    }
}
