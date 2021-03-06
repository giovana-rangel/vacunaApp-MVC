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
    public class PersonaService
    {
        private DBContext dBContext;
        private IMongoCollection<Persona> personasCollection;

        public PersonaService() {
            dBContext = new DBContext();
            personasCollection = dBContext.database.GetCollection<Persona>("Personas");
        }

        public List<Persona> GetPersonas() {
            List<Persona> personas = personasCollection.AsQueryable<Persona>().ToList();
            return personas;
        }
        
        public Persona GetPersona(string id)
        {
            var personaId = new ObjectId(id);
            var persona = personasCollection.AsQueryable<Persona>().SingleOrDefault(p => p.Id == personaId);
            return persona;
        }

        public void CrearPersona(Persona persona) 
        {
            personasCollection.InsertOne(persona);
        }

        public void EditarPersona(Persona persona)
        {
            personasCollection.ReplaceOne(p => p.Id == persona.Id, persona);
        }

        public void EliminarPersona() { 
            // sin implementar
        }
    }
}