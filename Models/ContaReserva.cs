using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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