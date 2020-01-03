using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Waybill.Models;
using Waybill.Repositories.Interfaces;
using Waybill.Services.Interfaces;

namespace Waybill.Services
{
    class LocalisationService : ILocalisationService
    {
        private readonly ILocalisationRepository _localisationRepository;

        public LocalisationService(ILocalisationRepository localisationRepository) => _localisationRepository = localisationRepository;

        public async Task AddLocalisationAsync(Localisation localisation) => await _localisationRepository.CreateAsync(localisation);

        public async Task DeleteLocalisationAsync(int id) => await _localisationRepository.DeleteAsync(id);

        public async Task EditLocalisationAsync(Localisation localisation) => await _localisationRepository.UpdateAsync(localisation);

        public async Task<List<Localisation>> GetAllLocalisationsAsync() => await _localisationRepository.GetAll().ToListAsync();

        public async Task<Localisation> GetLocalisationByIdAsync(int id) => await _localisationRepository.GetByIdAsync(id);

        public async Task<string> GetLocalisationZipCodeByStreetAndCity(string street, string city) => await _localisationRepository.GetLocalisationZipCodeByStreetAndCity(street, city);
    }
}
