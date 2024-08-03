using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DosStore.Models;

[Table("produto")]
public class ProdutoModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Required]
    public string nome { get; set; }
    
    [Required]
    public double valor { get; set; }
    
    [Required]
    public int quantidade { get; set; }
}