using NumerologiaCabalistica.Models.TextosNumericos;

namespace NumerologiaCabalistica.Data.DTO.Texto
{
    public class ReadTextoDTO
    {
        public int Numero { get; set; }
        public string Texto { get; set; }

        public CategoriaNumeroPessoalModel Categoria  { get; set; }

    }
}
