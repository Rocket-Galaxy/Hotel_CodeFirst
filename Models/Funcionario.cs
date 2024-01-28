using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
namespace Hotel_CodeFirst.Models
{ 
    public class Funcionario
    { 
        [Key]
        public int Codigo_Funcionario { get; set; }
        public string Nome_Funcionario { get; set; }

        public TipoFuncionario TipoFuncionario { get; set; }
    }
}