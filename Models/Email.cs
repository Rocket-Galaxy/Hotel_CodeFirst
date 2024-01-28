using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_CodeFirst.Models
{
    public class Email
    {
        [Key]

        public int Codigo_Email { get; set; }

        [Required]
        [ForeignKey("Codigo_Cliente")]
        public int Codigo_Cliente { get; set; }

        [Required]
        [StringLength(150)]
        public string? Endereco_Email { get; set; }

    }
}