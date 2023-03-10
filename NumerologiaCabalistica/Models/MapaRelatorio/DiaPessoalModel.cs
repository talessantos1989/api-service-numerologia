using NumerologiaCabalistica.Models.TextosNumericos;

namespace NumerologiaCabalistica.Models.MapaRelatorio
{
    public class DiaPessoalModel
    {
        public int CategoriaId
        {
            get
            {
                return 6;
            }
        }
        public List<DiasPessoais> DiasPessoais { get; set; }

    }


    public class DiasPessoais
    {
        public string Texto { get; set; }

        public int Numero { get; set; }
    }
}
