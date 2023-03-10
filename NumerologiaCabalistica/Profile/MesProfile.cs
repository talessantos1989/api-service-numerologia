using NumerologiaCabalistica.Data.DTO.DiasDoMesFavoraveis;
using NumerologiaCabalistica.Models.DiasMesFavoraveis;

namespace NumerologiaCabalistica.Profile
{
    public class MesProfile : AutoMapper.Profile
    {

        public MesProfile() 
        {
            CreateMap<MesModel, CreateMesDTO>();
            CreateMap<CreateMesDTO, MesModel>();
            CreateMap<ReadMesDTO, MesModel>();
            CreateMap<MesModel, ReadMesDTO>();
        }
    }
}
