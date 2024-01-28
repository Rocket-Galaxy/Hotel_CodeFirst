using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [StringLength(5)]
        public string Numero_Quarto { get; set; }

        public Quarto Quarto { get; set; }

        public Cliente Cliente { get; set; }

        public ContaReserva ContaReserva { get; set; }

        public NotaFiscal NotaFiscal { get; set; }
    }
}