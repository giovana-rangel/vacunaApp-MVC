using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vacunaApp.Models
{
    public class Vacunas
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("TipoVacuna")]
        public string TipoVacuna { get; set; }

        [BsonElement("Stock")]
        [Required, Range(1,10000, ErrorMessage = "El valor no puede ser 0")]
        public int Stock { get; set; }

        [BsonElement("CentroMedico")]
        [Required(ErrorMessage = "Este campo es obligatorio"), MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúüÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras")]
        public string CentroMedico { get; set; }


        public int ActualizarStock()
        {
            this.Stock = this.Stock - 1;
            return this.Stock;
        }
    }
}