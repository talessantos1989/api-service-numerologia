using AutoMapper;
using NumerologiaCabalistica.Data.DTO.Texto;
using NumerologiaCabalistica.Models.TextosNumericos;

namespace NumerologiaCabalistica.Profile
{
    public class TextoProfile : AutoMapper.Profile
    {
        public TextoProfile()
        {
            CreateMap<CreateTextoDTO, TextoNumericoModel>();
            CreateMap<TextoNumericoModel, ReadTextoDTO>();
            CreateMap<UpdateTextoDTO, ReadTextoDTO>();
            CreateMap<ReadTextoDTO, TextoNumericoModel>();
        }
    }
}
