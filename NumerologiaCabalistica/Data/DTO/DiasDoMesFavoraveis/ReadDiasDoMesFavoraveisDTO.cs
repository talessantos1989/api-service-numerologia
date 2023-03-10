using NumerologiaCabalistica.Models.DiasMesFavoraveis;

namespace NumerologiaCabalistica.Data.DTO.DiasDoMesFavoraveis
{
    public class ReadDiasDoMesFavoraveisDTO
    {
        public MesModel Mes { get; set; }

        public int Dia { get; set; }

        public int DiasFavoraveis { get; set; }

    }
}
