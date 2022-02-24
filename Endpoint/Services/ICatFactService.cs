using Endpoint.Models;
using System.Threading.Tasks;

namespace Endpoint.Services
{
    public interface ICatFactService
    {
        Task<CatFact> GetCatFact();
        Task<bool> SaveCatFact(CatFact fact);
    }
}
