using System.Collections.Generic;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel_CodeFirst.Models
{ 
    public class Funcionario
    { 
        [Key]

        public int Codigo_Funcionario { get; set; }
        public string Nome_Funcionario { get; set; }
        [ForeignKey("Codigo_TipoFuncionario")]
        public int Codigo_TipoFuncionario { get; set; }
    }
}