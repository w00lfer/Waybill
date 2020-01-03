using AutoMapper;
using Waybill.Models;
using Waybill.Services.Interfaces;

namespace Waybill.Mapping.Resolvers
{
    class ComputerWeightResolver : IValueResolver<ShipmentDTO, Shipment, int>
    {
        private readonly IComputerService _computerService;

        public ComputerWeightResolver(IComputerService computerService) =>_computerService = computerService;

        public int Resolve(ShipmentDTO source, Shipment destination, int destMember, ResolutionContext context) => 
            _computerService.GetComputerWeightByModelNameAsync(source.ModelName).Result;
    }
}
