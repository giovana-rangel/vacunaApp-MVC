using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using System.Configuration;
using vacunaApp.App_Start;
using MongoDB.Driver;
using vacunaApp.Models;
namespace vacunaApp.Services
{
    public class AplicacionesService
    {
        private DBContext dbContext;
        private IMongoCollection<Aplicaciones> AplicacionesCollection;

        public AplicacionesService()
        {
            dbContext = new DBContext();
            AplicacionesCollection = dbContext.database.GetCollection<Aplicaciones>("Aplicaciones");
        }

        public List<Aplicaciones> GetAplicaciones()
        {
            List<Aplicaciones> aplicaciones = AplicacionesCollection.AsQueryable<Aplicaciones>().ToList();
            return aplicaciones;
        }

        public void CrearAplicaciones(Aplicaciones Aplicaciones)
        {
            AplicacionesCollection.InsertOne(Aplicaciones);
        }
    }
}