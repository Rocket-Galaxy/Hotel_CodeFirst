using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Hotel_CodeFirst.Models
{ 

    public class ConsumoFrigobar
    {
        [Key]
        public int Codigo_ConsumoFrigobar { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public ContaReserva ContaReserva { get; set; }

        public Frigobar Frigobar { get; set; }
    }

}