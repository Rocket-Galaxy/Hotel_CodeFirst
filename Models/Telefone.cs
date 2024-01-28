using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Hotel_CodeFirst.Models
{
    public class Telefone
    {
        [Key]
        public int Codigo_Telefone { get; set; }

        [Required]
        [StringLength(20)]
        public string Numero_Telefone { get; set; }

        public Cliente Cliente { get; set; }
    }
}