using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace vacunaApp.Models
{
    public class Persona
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio"), MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúüÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras")]
        public string Nombre { get; set; }

        [BsonElement("TipoDocumento")]
        public string TipoDocumento { get; set; }

        [BsonElement("NumeroDocumento")]
        [Required(ErrorMessage = "Este campo es obligatorio"), MaxLength(8, ErrorMessage = "Máximo 8 caracteres")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten numeros sin caracteres especiales")]
        public string NumeroDocumento { get; set; }

        [BsonElement("Nacionalidad")]
        [Required(ErrorMessage = "Este campo es obligatorio"), MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúüÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras")]
        public string Nacionalidad { get; set; }

        [BsonElement("FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [BsonElement("contacto")]
        public Contacto contacto { get; set; }

        [BsonElement("Direccion")]
        public Direccion Direccion { get; set; }

        [BsonElement("DosisAplicadas")]
        public List<Aplicacion> DosisAplicadas { get; set; } = new List<Aplicacion>();
    }
}