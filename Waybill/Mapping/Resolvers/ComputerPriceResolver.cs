using AutoMapper;
using Waybill.Models;
using Waybill.Services.Interfaces;

namespace Waybill.Mapping.Resolvers
{
    class ComputerPriceResolver : IValueResolver<ShipmentDTO, Shipment, int>
    {
        private readonly IComputerService _computerService;

        public ComputerPriceResolver(IComputerService computerService) => _computerService = computerService;

        public int Resolve(ShipmentDTO source, Shipment destination, int destMember, ResolutionContext context) => _computerService.GetComputerPriceByModelNameAsync(source.ModelName).Result;
    }
}
