using System;
using Api_Mongo.infrastructure.Entities;
using MongoDB.Driver;

namespace Api_Mongo.infrastructure.Database
{
    public class DbConnection
    {
        public IMongoDatabase database;
        public DbConnection(){

            try{

                var client = new MongoClient("ConnectionString");
                database = client.GetDatabase("Database");

            }catch(Exception ex)
            {
                throw new MongoException("It was not possible to connect to Database", ex);
            }
        }
    }
}