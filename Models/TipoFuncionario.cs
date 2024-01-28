using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Hotel_CodeFirst.Models
{ 
    public class TipoFuncionario
    { 
        [Key]
        public int Codigo_TipoFuncionario { get; set; }
        public string Desc_TipoFuncionario { get; set; }
    }
}