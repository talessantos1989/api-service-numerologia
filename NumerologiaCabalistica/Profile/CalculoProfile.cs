
using NumerologiaCabalistica.Data.DTO.CalculoCabalistico;
using NumerologiaCabalistica.Models.MapaRelatorio;

namespace NumerologiaCabalistica.Profile;

public class CalculoProfile : AutoMapper.Profile
{
    public CalculoProfile()
    {
        CreateMap<ParametroCalculoNumerologia, ReadParametroCalculoNumerologiaDTO>();
        CreateMap<ReadParametroCalculoNumerologiaDTO, ParametroCalculoNumerologia>();
    }
}
