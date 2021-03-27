using System;
using System.ComponentModel.DataAnnotations;

namespace Api_Mongo.infrastructure.Entities
{
    public class InfectedDTO
    {
        [Required]
        public string Cpf { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string Sexo { get; set; }
        public bool IsDeleted { get; set; } = false;

        [Required]
        public double Latitude { get; set; }
        
        [Required]
        public double Longitude { get; set; }
    }
}