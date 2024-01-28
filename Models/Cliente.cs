using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_CodeFirst.Models
{ 
    public class Cliente
    {
        [Key]
        public int Codigo_Cliente { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome_Cliente { get; set; }

        [Required]
        [StringLength(100)]
        public string Nacionalidade_Cliente { get; set; }

    }

}