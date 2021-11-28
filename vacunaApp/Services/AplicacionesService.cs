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

        public void CrearAplicacion(Aplicacion Aplicacion)
        {
            AplicacionesCollection.InsertOne(Aplicacion);
        }

        public List<Aplicacion> BuscarAplicacionesPorTipo(List<Aplicacion> aplicaciones, string key)
        {
            List<Aplicacion> aplicacionesFiltradas = aplicaciones.FindAll(a => a.Vacuna == key);
            return aplicacionesFiltradas;
        }

        public List<Aplicacion> BuscarAplicacionesPorFecha(List<Aplicacion> aplicaciones, DateTime desde, DateTime hasta)
        {
            List<Aplicacion> aplicacionesFiltradas = aplicaciones.FindAll(a => a.Fecha > desde && a.Fecha < hasta);
            return aplicacionesFiltradas;
        }
    }
}