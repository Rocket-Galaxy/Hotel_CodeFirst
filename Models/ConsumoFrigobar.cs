using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hotel_CodeFirst.Models
{ 

    public class ConsumoFrigobar
    {
        [Key]

        public int Codigo_ConsumoFrigobar { get; set; }

        [Required]
        public int Quantidade { get; set; }
        // Relacionamento muitos para um com Filial
        [ForeignKey("Codigo_ContaReserva")]
        public int Codigo_ContaReserva { get; set; }

        [ForeignKey("Codigo_Frigobar")]
        public int Codigo_Frigobar { get; set; }

    }

}