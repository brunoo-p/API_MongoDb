using System;
using System.Threading.Tasks;
using Api_Mongo.infrastructure.Database;
using Api_Mongo.infrastructure.Entities;
using Api_Mongo.infrastructure.Interfaces;
using MongoDB.Driver;

namespace Api_Mongo.Domain.Repositories
{
    public class InfectedRepository : IInfected
    {
        DbConnection _mongoDB;
        IMongoCollection<Infected> _infectedCollection;

        public InfectedRepository(DbConnection connection)
        {
             _mongoDB = connection;
            _infectedCollection = _mongoDB.database.GetCollection<Infected>("Infected");
        }
        public bool AddInfected(InfectedDTO dto)
        {
            try{

                var newInfected = new Infected(
                    dto.Cpf,
                    dto.DataNascimento,
                    dto.Sexo,
                    dto.Latitude,
                    dto.Longitude
                );

                _infectedCollection.InsertOne(newInfected);
                return true;

            }catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> ConfigureData(InfectedDTO dto)
        {

            var newData = new Infected(
                    dto.Cpf,
                    dto.DataNascimento,
                    dto.Sexo,
                    dto.Latitude,
                    dto.Longitude
            );

            try{
                await _infectedCollection.FindOneAndDeleteAsync(Builders<Infected>.Filter.Where(_ => _.Cpf == dto.Cpf));
                _infectedCollection.InsertOne(newData);
                
                //_infectedCollection.UpdateOne(Builders<Infected>.Filter.Where(_ => _.Cpf == dto.Cpf), Builders<Infected>.Update.Set("Latitude", dto.Latitude).Set("Longitude", dto.Longitude));

                return true;
            
            }catch
            {
                return false;
            }   
        }

        public bool RemoveInfected(InfectedDTO dto)
        {
            var newInfected = new Infected(
                    dto.Cpf,
                    dto.DataNascimento,
                    dto.Sexo,
                    dto.Latitude,
                    dto.Longitude
                );

            try{
                _infectedCollection.UpdateOne(Builders<Infected>.Filter.Where(_ => _.Cpf == dto.Cpf), Builders<Infected>.Update.Set("IsDeleted", dto.IsDeleted));

                return true;
            
            }catch
            {
                return false;
            }
        }
    }
}