namespace NumerologiaCabalistica.Models.MapaRelatorio
{
    public class TerceiroCicloDeVidaModel
    {
        public int CategoriaId
        {
            get
            {
                return 29;
            }
        }

        public int Numero { get; set; }
        public string Texto { get; set; }

        public int AnoDe{ get; set; }

        public int IdadeDe { get; set; }

        public string IdadeAte { get { return "até o final da vida"; } }
    }
}
