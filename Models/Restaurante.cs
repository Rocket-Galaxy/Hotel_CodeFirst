using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Hotel_CodeFirst.Models
{ 

    public class Restaurante
    {
        [Key]
        public int Codigo_Restaurante { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome_ItemMenu { get; set; }

        [Required]
        public decimal Preco_ItemMenu { get; set; }
    }

}