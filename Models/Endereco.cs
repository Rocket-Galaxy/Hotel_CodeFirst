using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel_CodeFirst.Models
{ 
    public class Endereco
    {
        [Key]

        public int Codigo_Endereco { get; set; }
        // Relacionamento muitos para um com Filial
        [ForeignKey("Codigo_Cliente")]
        public int Codigo_Cliente { get; set; }

        [Required]
        [StringLength(100)]
        public string Rua_Endereco { get; set; }

        [Required]
        [StringLength(10)]
        public string Numero_Endereco { get; set; }

        [Required]
        [StringLength(30)]
        public string Complemento_Endereco { get; set; }

        [Required]
        [StringLength(100)]
        public string Bairro_Endereco { get; set; }

        [Required]
        [StringLength(100)]
        public string Cidade_Endereco { get; set; }

        [Required]
        [StringLength(50)]
        public string Estado_Endereco { get; set; }

        [Required]
        [StringLength(100)]
        public string Pais_Endereco { get; set; }

    }
}
