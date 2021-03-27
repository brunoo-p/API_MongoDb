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

                var client = new MongoClient("mongodb://brunoo-p:false@cluster-shard-00-00.oyyye.mongodb.net:27017,cluster-shard-00-01.oyyye.mongodb.net:27017,cluster-shard-00-02.oyyye.mongodb.net:27017/Covid19?ssl=true&replicaSet=atlas-b0z4pc-shard-0&authSource=admin&retryWrites=true&w=majority");
                database = client.GetDatabase("Covid19");

            }catch(Exception ex)
            {
                throw new MongoException("It was not possible to connect to Database", ex);
            }
        }
    }
}