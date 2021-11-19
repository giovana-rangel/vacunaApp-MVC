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
        private IMongoCollection<Aplicacion> AplicacionesCollection;

        public AplicacionesService()
        {
            dbContext = new DBContext();
            AplicacionesCollection = dbContext.database.GetCollection<Aplicacion>("Aplicaciones");
        }

        public List<Aplicacion> GetAplicaciones()
        {
            List<Aplicacion> aplicaciones = AplicacionesCollection.AsQueryable<Aplicacion>().ToList();
            return aplicaciones;
        }

        public void CrearAplicaciones(Aplicacion Aplicaciones)
        {
            AplicacionesCollection.InsertOne(Aplicaciones);
        }
    }
}