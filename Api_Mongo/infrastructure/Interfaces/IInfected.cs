using System.Threading.Tasks;
using Api_Mongo.infrastructure.Entities;

namespace Api_Mongo.infrastructure.Interfaces
{
    public interface IInfected
    {
        bool AddInfected(InfectedDTO dto);
        Task<bool> ConfigureData(InfectedDTO dto);
        bool RemoveInfected(InfectedDTO dto);
    }
}