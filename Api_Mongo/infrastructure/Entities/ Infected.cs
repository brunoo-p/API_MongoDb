using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api_Mongo.infrastructure.Entities
{
    public class Infected : Base
    {
        [Required]
        public string Cpf { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
        
        [Required]
        public string Sexo { get; set; }
        public bool IsDeleted { get; set; } = false;
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }

        public Infected(string cpf, DateTime dataNascimento, string sexo, double latitude, double longitude)
        {
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
    }

}