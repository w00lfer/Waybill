using System.Threading.Tasks;
using Waybill.Models;

namespace Waybill.Repositories.Interfaces
{
    public interface  ILocalisationRepository : IGenericRepository<Localisation>
    {
        public Task<string> GetLocalisationZipCodeByStreetAndCity(string street, string city);
    }
}
