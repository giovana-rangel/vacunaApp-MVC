using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
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
        public int Stock { get; set; }
        [BsonElement("CentroMedico")]
        public string CentroMedico { get; set; }


        public int ActualizarStock()
        {
            this.Stock = this.Stock - 1;
            return this.Stock;
        }
    }
}