using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Hotel_CodeFirst.Models
{ 

    public class ConsumoLavanderia
    {
        [Key]
        public int Codigo_ConsumoLavanderia { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public ContaReserva ContaReserva { get; set; }

        public ServicoLavanderia ServicoLavanderia { get; set; }
    }

}