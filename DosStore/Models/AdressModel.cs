using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DosStore.Models;

[Table("enderecos")]
public class AdressModel
{
    [Key]
    public int id { get; set; }
    
    [Required]
    public string rua { get; set; }
    
    [Required]
    public string numero { get; set; }
    
    [Required]
    public string complemento { get; set; }
    
    [Required]
    public string bairro { get; set; }
    
    [Required]
    public string cidade { get; set; }
    
    [Required]
    public string cep { get; set; }
    
    [Required]
    public string pontoReferencia { get; set; }
    
    [Required]
    public ClienteModel cliente { get; set; }
}