using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace vacunaApp.Models
{
    public class Direccion
    {
        [BsonElement("Ciudad")]
        [Required(ErrorMessage = "Este campo es obligatorio"), MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúüÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras")]
        public string Ciudad { get; set; }

        [BsonElement("Provincia")]
        [Required(ErrorMessage = "Este campo es obligatorio"), MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúüÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras")]
        public string Provincia { get; set; }

        [BsonElement("CodigoPostal")]
        [Required(ErrorMessage = "Este campo es obligatorio"), MaxLength(8, ErrorMessage = "Máximo de 8 caracteres")]
        [RegularExpression(@"^[a-zA-ZñÑ0-9\s]+$", ErrorMessage = "No se permiten caracteres especiales")]
        public string CodigoPostal { get; set; }

        [BsonElement("Calle")]
        [Required(ErrorMessage = "Este campo es obligatorio"), MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Calle { get; set; } 

        [BsonElement("NumeroCalle")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten numeros sin caracteres especiales")]
        public string NumeroCalle { get; set; }

        [BsonElement("Otro")]
        public string Otro { get; set; }
    }
}