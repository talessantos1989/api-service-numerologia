namespace NumerologiaCabalistica.Models.MapaRelatorio
{
    public class LicaoCarmicaModel
    {
        public int NumeroCategoria
        {
            get
            {
                return 11;
            }
            set
            {
            }
        }

        public List<Licoes> LicoesCarmicas { get; set; }
    }

    public class Licoes
    {
        public string Texto { get; set; }

        public int Numero { get; set; }
    }
}
