using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vacunaApp.Models
{
    public class Aplicaciones
    {
        [BsonId]
        public ObjectId Id {get; private set;}
        [BsonElement("Usuario")]
        public Persona Persona { get; private set; }
        [BsonElement("Vacunas")]
        public Vacunas Vacunas { get; private set; }
        [BsonElement("Dosis")]
        public string Dosis { get; private set; }


        public Aplicaciones(Persona persona, Vacunas vacunas, string dosis)
        {
            this.Id = new ObjectId();
            this.Persona = persona;
            this.Vacunas = Vacunas;
            this.Dosis = dosis;
        }
    }

    
}