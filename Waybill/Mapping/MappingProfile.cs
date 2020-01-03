using AutoMapper;
using Waybill.Mapping.Resolvers;
using Waybill.Models;

namespace Waybill.Mapping
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShipmentDTO, Shipment>()
                .ForMember(s => s.Weight, opt => opt.MapFrom<ComputerWeightResolver>())
                .ForMember(s => s.Price, opt => opt.MapFrom<ComputerPriceResolver>())
                .ForMember(s => s.ZipCode, opt => opt.MapFrom<LocalisationZipCodeResolver>());
        }
    }
}
