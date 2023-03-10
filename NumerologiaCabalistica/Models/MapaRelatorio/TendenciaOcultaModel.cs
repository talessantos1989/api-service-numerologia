namespace NumerologiaCabalistica.Models.MapaRelatorio
{
    public class TendenciaOcultaModel
    {
        public int CategoriaId
        {
            get
            {
                return 28;
            }
            set
            {
            }
        }

        public List<TendenciasOcultas> TendenciasOcultas { get; set; }
    }

    public class TendenciasOcultas
    {
        public string Texto { get; set; }

        public int Numero { get; set; }
    }
}
