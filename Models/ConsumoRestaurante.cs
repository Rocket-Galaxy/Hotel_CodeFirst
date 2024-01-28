using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Hotel_CodeFirst.Models
{ 
    public class ConsumoRestaurante
    {
        [Key]

        public int Codigo_ConsumoRestaurante { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public bool EntregueNoQuarto { get; set; }

        [ForeignKey("Codigo_ContaReserva")]
        public int Codigo_ContaReserva { get; set; }

        [ForeignKey("Codigo_Restaurante")]
        public int Codigo_Restaurante { get; set; }
    }
}