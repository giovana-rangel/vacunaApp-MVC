using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace vacunaApp.Models
{
    public class Contacto
    {
        [BsonElement("Telefono")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression(@"^[+-]?\d+(\.\d+)?$", ErrorMessage = "Solo se admiten números sin caracteres especiales")]
        public string Telefono { get; set; }
        [BsonElement("TelefonoEmergencia")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression(@"^[+-]?\d+(\.\d+)?$", ErrorMessage = "Solo se admiten números sin caracteres especiales")]
        public string TelefonoEmergencia { get; set; }
        [BsonElement("Email")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression(@"^[a-zA-Z0-9_\.-]+@([a-zA-Z]+\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email no válido")]
        public string Email { get; set; }

    }
}