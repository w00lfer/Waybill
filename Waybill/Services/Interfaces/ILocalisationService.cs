using System.Collections.Generic;
using System.Threading.Tasks;
using Waybill.Models;

namespace Waybill.Services.Interfaces
{
    public interface ILocalisationService
    {
        public Task<List<Localisation>> GetAllLocalisationsAsync();
        public Task<Localisation> GetLocalisationByIdAsync(int id);
        public Task<string> GetLocalisationZipCodeByStreetAndCity(string street, string city);
        public Task AddLocalisationAsync(Localisation localisation);
        public Task EditLocalisationAsync(Localisation localisation);
        public Task DeleteLocalisationAsync(int id);
    }
}
