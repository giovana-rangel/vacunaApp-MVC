using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;

namespace vacunaApp.App_Start
{
    public class DBContext
    {
        public IMongoDatabase database;
        public DBContext() {
            var client = new MongoClient(ConfigurationManager.AppSettings["MongoDBHost"]);
            database = client.GetDatabase(ConfigurationManager.AppSettings["MongoDBName"]);
        }
    }
}