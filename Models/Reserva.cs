using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_CodeFirst.Models
{ 
        public class Reserva
    {
        [Key]

        public int Codigo_Reserva { get; set; }

        [Required]
        public DateTime DataInicio_Reserva { get; set; }

        [Required]
        public DateTime DataFim_Reserva { get; set; }

        [Required]
        public bool Cancelada_Reserva { get; set; }

        [Required]
        [ForeignKey("Numero_Quarto")]
        public int Numero_Quarto { get; set; }

        [ForeignKey("Codigo_ContaReserva")]
        public int? Codigo_ContaReserva { get; set; }

        [ForeignKey("Codigo_NotaFiscal")]
        public int? Codigo_NotaFiscal { get; set; }
        
        [ForeignKey("Codigo_Cliente")]
        public int Codigo_Cliente { get; set; }

    }
}