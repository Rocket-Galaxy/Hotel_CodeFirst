using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Hotel_CodeFirst.Models
{
    public class Quarto
    {
        [Key]

        public int Numero_Quarto { get; set; }

        // Relacionamento muitos para um com Filial
        [ForeignKey("Codigo_Filial")]
        public int Codigo_Filial { get; set; }
//        public Filial Filial { get; set; }

        // Relacionamento muitos para um com Filial
        [ForeignKey("Codigo_TipoQuarto")]
        public int Codigo_TipoQuarto { get; set; }
  //      public TipoQuarto TipoQuarto { get; set; }
    }

}