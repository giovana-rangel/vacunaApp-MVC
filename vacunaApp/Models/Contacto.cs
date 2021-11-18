using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace vacunaApp.Models
{
    public class Contacto
    {
        [BsonElement("Telefono")]
        public string Telefono { get; set; }
        [BsonElement("TelefonoEmergencia")]
        public string TelefonoEmergencia { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }

    }
}