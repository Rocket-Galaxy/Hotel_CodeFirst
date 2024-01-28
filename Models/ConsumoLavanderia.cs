using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hotel_CodeFirst.Models
{ 

    public class ConsumoLavanderia
    {
        [Key]

        public int Codigo_ConsumoLavanderia { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [ForeignKey("Codigo_ContaReserva")]
        public int Codigo_ContaReserva { get; set; }

        [ForeignKey("Codigo_ServicoLavanderia")]
        public int Codigo_ServicoLavanderia { get; set; }
    }

}