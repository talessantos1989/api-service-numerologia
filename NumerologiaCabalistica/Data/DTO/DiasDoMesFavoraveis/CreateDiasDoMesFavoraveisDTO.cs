using NumerologiaCabalistica.Models.DiasMesFavoraveis;

namespace NumerologiaCabalistica.Data.DTO.DiasDoMesFavoraveis
{
    public class CreateDiasDoMesFavoraveisDTO
    {
        public int Dia { get; set; }
        public int MesId { get; set; }
        public int DiaFavoravel { get; set; }

    }
}
