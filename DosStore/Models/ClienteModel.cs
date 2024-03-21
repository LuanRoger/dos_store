using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DosStore.Models;

[Table("clientes")]
[Index(nameof(email), IsUnique = true)]
public class ClienteModel
{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
        [Required]
        public string nome { get; set; }
        
        [Required]
        public string email { get; set; }
        
        [Required]
        public DateTime dataNascimento { get; set; }
        
        [Required]
        public string tellNumb { get; set; }
}