using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_CodeFirst.Models
{ 

    public class Frigobar
    {
        [Key]

        public int Codigo_Frigobar { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome_ItemFrigobar { get; set; }

        [Required]
        public decimal Preco_ItemFrigobar { get; set; }
    }

}