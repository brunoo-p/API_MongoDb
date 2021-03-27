
using System.Threading.Tasks;
using Api_Mongo.Domain.Service;
using Api_Mongo.infrastructure.Database;
using Api_Mongo.infrastructure.Entities;
using Api_Mongo.infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api_Mongo.Application.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InfectedController : ControllerBase
    {
        DbConnection _mongoDB;
        IMongoCollection<Infected> _infectedCollection;
        IInfected _repository;
        public InfectedController(IInfected repository, DbConnection connection)
        {
            _mongoDB = connection;
            _infectedCollection = _mongoDB.database.GetCollection<Infected>("Infected");
            _repository = repository;
        }

        [HttpPost]
        public ActionResult RegisterInfected([FromBody] InfectedDTO dto)
        {
            bool valid = EmailValidator.Validar(dto.Cpf);
            if(!valid)
            {
                return StatusCode(403, "CPF inválido.");
            }

            var infectedSaved =  _repository.AddInfected(dto);

            if(!infectedSaved)
            {
                return StatusCode(501, "Erro ao registrar novo infectado. Tente novamente mais tarde");
            }

            return StatusCode(201, "Infectado registrado com sucesso!");
        }
        [HttpGet]
        public ActionResult GetInfected()
        {
            var infectedList = _infectedCollection.Find(Builders<Infected>.Filter.Where(_ => _.IsDeleted != true)).ToList();
            if(infectedList == null){
                return Ok("Ninguém registrado.");
            }
            return Ok(infectedList);
        }

        [HttpPut]
        public async Task<ActionResult> ConfigureData([FromBody] InfectedDTO dto)
        {
            bool valid = EmailValidator.Validar(dto.Cpf);
            if(!valid)
            {
                return StatusCode(403, "CPF inválido.");
            }

            var changed = await _repository.ConfigureData(dto);
            if(!changed)
            {
                return StatusCode(500, "Não foi possível fazer esta mudança agora. Tente novamente mais tarde");
            }
            return StatusCode(201, "Dados Atualizados");
        }

        [HttpDelete]
        public ActionResult FlagAsDelete(InfectedDTO dto)
        {
            bool valid = EmailValidator.Validar(dto.Cpf);
            if(!valid)
            {
                return StatusCode(403, "CPF inválido.");
            }
            
            var deleted = _repository.RemoveInfected(dto);
            if(!deleted)
            {
                return StatusCode(500, "Não foi possível remover este registro. Tente novamente mais tarde");
            }
            return StatusCode(201, "Registro removido com sucesso");
        }
    }
}