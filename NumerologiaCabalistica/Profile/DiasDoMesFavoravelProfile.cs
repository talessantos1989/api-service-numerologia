using AutoMapper;
using NumerologiaCabalistica.Data.DTO.DiasDoMesFavoraveis;
using NumerologiaCabalistica.Models.DiasMesFavoraveis;

namespace NumerologiaCabalistica.Profile
{
    public class DiasDoMesFavoravelProfile : AutoMapper.Profile
    {
        public DiasDoMesFavoravelProfile()
        {
            CreateMap<CreateDiasDoMesFavoraveisDTO, DiaDoMesFavoravelModel>();
            CreateMap<DiaDoMesFavoravelModel, CreateDiasDoMesFavoraveisDTO>();
            CreateMap<DiaDoMesFavoravelModel, ReadDiasDoMesFavoraveisDTO>();
            CreateMap<ReadDiasDoMesFavoraveisDTO, DiaDoMesFavoravelModel>();
        }
    }
}
