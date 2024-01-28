using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_CodeFirst.Models
{
    public class Quarto
    {
        [Key]
        [StringLength(5)]
        public string Numero_Quarto { get; set; }

        public TipoQuarto TipoQuarto { get; set; }
    }
}