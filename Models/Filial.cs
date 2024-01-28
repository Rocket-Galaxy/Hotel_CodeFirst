using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_CodeFirst.Models
{
    public class Filial
    {
        [Key]
        public int Codigo_Filial { get; set; }

        [StringLength(100)]
        [Required]
        public string Nome_Filial { get; set; }

        [Required]
        public int NumeroQuartos_Filial { get; set; }

        [Required]
        public string Endereco_Filial { get; set; }

        [Required]
        public int QuantidadeEstrelas_Filial { get; set; }
    }
}
