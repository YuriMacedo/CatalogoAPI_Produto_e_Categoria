using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Model
{
    public class Produto
    {
        [JsonIgnore]
        [Key]
        public int ProdutoId { get; set; }
        [Required]
        [StringLength(300)]
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Required]
        public decimal Preco { get; set; }
        public string? ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CategoriaId { get; set; }
        [JsonIgnore]
        public Categoria? Categoria { get; set; }


    }
}
