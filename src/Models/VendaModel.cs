using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DosStore.Models;

[Table("sale")]
public class VendaModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    public Collection<ProdutoModel> produtosComprados { get; set; }
    public ClienteModel cliente { get; set; }
}