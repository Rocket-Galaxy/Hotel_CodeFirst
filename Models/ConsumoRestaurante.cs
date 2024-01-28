using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;


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

        public ContaReserva ContaReserva { get; set; }

        public Restaurante Restaurante { get; set; }
    }
}