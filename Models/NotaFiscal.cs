using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_CodeFirst.Models
{
    public class NotaFiscal
    {
        [Key]
        public int Codigo_NotaFiscal { get; set; }

        [Required]
        [StringLength(35)]
        public string Numero_NotaFiscal { get; set; }

        [Required]
        public DateTime Data_NotaFiscal { get; set; }

        [Required]
        public decimal ValorTotal_NotaFiscal { get; set; }

        public TipoPagamento TipoPagamento { get; set; }
    }
}