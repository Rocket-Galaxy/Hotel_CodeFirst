using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_CodeFirst.Models
{ 
    public class TipoPagamento
    {
        [Key]
        public int Codigo_TipoPagamento { get; set; }

        [Required]
        [StringLength(50)]
        public string Desc_TipoPagamento { get; set; }
    }
}