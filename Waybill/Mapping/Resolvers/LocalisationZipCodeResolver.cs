using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Waybill.Models;
using Waybill.Services.Interfaces;

namespace Waybill.Mapping.Resolvers
{
    class LocalisationZipCodeResolver : IValueResolver<ShipmentDTO, Shipment, string>
    {
        private readonly ILocalisationService _localisationService;

        public LocalisationZipCodeResolver(ILocalisationService localisationService) => _localisationService = localisationService;

        public string Resolve(ShipmentDTO source, Shipment destination, string zipCode, ResolutionContext context) =>
            _localisationService.GetLocalisationZipCodeByStreetAndCity(source.StreetAddress, source.City).Result;
    }
}
