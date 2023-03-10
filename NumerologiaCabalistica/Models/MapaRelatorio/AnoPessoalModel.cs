using NumerologiaCabalistica.Models.TextosNumericos;
using NumerologiaCabalistica.Models.TextosNumericos;

namespace NumerologiaCabalistica.Models.MapaRelatorio
{
    public class AnoPessoalModel
    {
        public int CategoriaId
        {
            get
            {
                return 1;
            }
        }
        public List<AnosPessoais> AnosPessoais { get; set; }

        public int AnoPessoalAtual { get; set; }

    }


    public class AnosPessoais
    {
        public string Texto { get; set; }

        public int AnoPessoal { get; set; }

        public DateTime DataDe { get; set; }
        public DateTime DataAte { get; set; }
    }
}
