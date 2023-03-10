using NumerologiaCabalistica.Models.TextosNumericos;
namespace NumerologiaCabalistica.Models.MapaRelatorio
{
    public class DividaCarmicaModel 
    {
        public int NumeroCategoria
        {
            get
            {
                return 7;
            }
        }

        public List<Dividas> DividasCarmicas { get; set; }
    }
    public class Dividas
    {
        public string Texto { get; set; }

        public int Numero { get; set; }
    }

}
