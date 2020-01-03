using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waybill.Models;
using Waybill.Repositories.Interfaces;

namespace Waybill.Repositories
{
    class LocalisationRepository : GenericRepository<Localisation>, ILocalisationRepository
    {
        public LocalisationRepository(AppDbContext appDbContext)
        : base(appDbContext)
        { }

        public async Task<string> GetLocalisationZipCodeByStreetAndCity(string street, string city) =>
             await GetAll().Where(l => l.Street == street && l.City == city).Select(l => l.ZipCode).FirstOrDefaultAsync();
    }
}
