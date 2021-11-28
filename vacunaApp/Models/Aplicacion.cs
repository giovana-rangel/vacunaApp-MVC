using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vacunaApp.Models
{
    public class Aplicacion
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Vacuna")]
        public string Vacuna { get;  set; }

        [BsonElement("Fecha")]
        public DateTime Fecha { get; set; }
    }  
}