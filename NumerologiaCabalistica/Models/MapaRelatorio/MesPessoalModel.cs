using NumerologiaCabalistica.Models.TextosNumericos;

namespace NumerologiaCabalistica.Models.MapaRelatorio
{
    public class MesPessoalModel
    {
        public int CategoriaId
        {
            get
            {
                return 14;
            }
            set
            {
            }
        }
        public List<MesesPessoais> MesesPessoais { get; set; }
    }

    public class MesesPessoais
    {
        public string Texto { get; set; }

        public int Numero { get; set; }

        public string MesDe { get; set; }
        public string MesAte { get; set; }

        public string MesExtenso { get; set; }
    }
}
