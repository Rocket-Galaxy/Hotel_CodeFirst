using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Hotel_CodeFirst.Models
{
    public class TipoQuarto
    {
        [Key]
        public int Codigo_TipoQuarto { get; set; }

        [Required]
        [StringLength(50)]
        public string Desc_TipoQuarto { get; set; }

        [Required]
        public decimal Valor_TipoQuarto { get; set; }
    }
}