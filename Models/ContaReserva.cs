using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_CodeFirst.Models
{ 
    public class ContaReserva
    {
        [Key]
        public int Codigo_ContaReserva { get; set; }

        [Required]
        public decimal ValorGasto_ContaReserva { get; set; }
    }
}