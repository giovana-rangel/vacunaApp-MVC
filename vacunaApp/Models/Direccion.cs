using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace vacunaApp.Models
{
    public class Direccion
    {
        [BsonElement("Ciudad")]
        public string Ciudad { get; set; }
        [BsonElement("Provincia")]
        public string Provincia { get; set; }
        [BsonElement("CodigoPostal")]
        public string CodigoPostal { get; set; }
        [BsonElement("Calle")]
        public string Calle { get; set; }
        [BsonElement("NumeroCalle")]
        public int NumeroCalle { get; set; }
        [BsonElement("Otro")]
        public string Otro { get; set; }
    }
}