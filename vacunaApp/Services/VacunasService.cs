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
    public class VacunasService
    {
        
        private DBContext dBContext;
        private IMongoCollection<Vacunas> vacunasCollection;

        public VacunasService()
        {
            dBContext = new DBContext();
            vacunasCollection = dBContext.database.GetCollection<Vacunas>("Vacunas");
        }
        public List<Vacunas> GetVacunas()
        {
            List<Vacunas> vacunas = vacunasCollection.AsQueryable<Vacunas>().ToList();
            return vacunas;
        }

        public Vacunas GetVacuna(string id)
        {
            var vacunaId = new ObjectId(id);
            var vacuna = vacunasCollection.AsQueryable<Vacunas>().SingleOrDefault(v => v.Id == vacunaId);
            return vacuna;
        }

        public void CrearVacunas(Vacunas vacunas)
        {
            vacunasCollection.InsertOne(vacunas);
        }

        public void EditarVacunas(Vacunas vacuna)
        {
            vacunasCollection.ReplaceOne(v => v.Id == vacuna.Id, vacuna);
        }

        public void EliminarVacunas()
        {
            // es un pluss
        }
        
    }
}