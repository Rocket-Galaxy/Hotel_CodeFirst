using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_CodeFirst.Models
{
    public class Telefone
    {
        [Key]

        public int Codigo_Telefone { get; set; }

        [Required]
        [StringLength(20)]
        public string Numero_Telefone { get; set; }

        
        [ForeignKey("Codigo_Cliente")]
        public int Codigo_Cliente { get; set; }
    }
}