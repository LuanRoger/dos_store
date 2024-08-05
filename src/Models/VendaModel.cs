using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DosStore.Models;

[Table("sale")]
public class VendaModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    [Required]
    public List<ProdutoModel> produtosComprados { get; set; } = new();
    [Required]
    [ForeignKey(nameof(cliente))]
    public int clienteId { get; set; }
    [Required]
    public ClienteModel cliente { get; set; }
    
    [Required]
    public double total { get; set; }
}