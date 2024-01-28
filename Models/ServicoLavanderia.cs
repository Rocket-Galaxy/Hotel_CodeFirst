using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Hotel_CodeFirst.Models
{ 
    public class ServicoLavanderia
    {
        [Key]
        public int Codigo_ServicoLavanderia { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao_ServicoLavanderia { get; set; }

        [Required]
        public decimal Preco_ServicoLavanderia { get; set; }
    }

}