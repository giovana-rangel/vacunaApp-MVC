using System;
using System.Collections.Generic;
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
        public string Nombre { get; set; }
        [BsonElement("TipoDocumento")]
        public string TipoDocumento { get; set; }
        [BsonElement("NumeroDocumento")]
        public int NumeroDocumento { get; set; }
        [BsonElement("Nacionalidad")]
        public string Nacionalidad { get; set; }
        [BsonElement("FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [BsonElement("contacto")]
        public Contacto contacto { get; set; }
        [BsonElement("Direccion")]
        public Direccion Direccion { get; set; }
        [BsonElement("PrimeraDosis")]
        public string PrimeraDosis { get; set; }
        [BsonElement("SegundaDosis")]
        public string SegundaDosis { get; set; }
        [BsonElement("TerceraDosis")]
        public string TerceraDosis { get; set; }
    }
}