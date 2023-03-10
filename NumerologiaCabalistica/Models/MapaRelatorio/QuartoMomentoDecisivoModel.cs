namespace NumerologiaCabalistica.Models.MapaRelatorio
{
    public class QuartoMomentoDecisivoModel
    {
        public int CategoriaId
        {
            get
            {
                return 21;
            }
        }

        public int Numero { get; set; }
        public string Texto { get; set; }

        public int AnoDe{ get; set; }

        public string AnoAte { get; set; }

        public int IdadeDe { get; set; }
        public string IdadeAte { get { return "até o final da vida"; } }

    }
}
