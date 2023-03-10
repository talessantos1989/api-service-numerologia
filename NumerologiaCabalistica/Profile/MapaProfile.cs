
using NumerologiaCabalistica.Data.DTO.MapaModel;
using NumerologiaCabalistica.Models.MapaRelatorio;

namespace NumerologiaCabalistica.Profile
{
    public class MapaProfile : AutoMapper.Profile
    {
        public MapaProfile()
        {
            CreateMap<ReadMapaDTO, MapaModel>();
            CreateMap<MapaModel, ReadMapaDTO>();
        }
    }
}
