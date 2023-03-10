namespace NumerologiaCabalistica.Models.MapaRelatorio
{
    public class TerceiroMomentoDecisivoModel
    {
        public int CategoriaId
        {
            get
            {
                return 30;
            }
        }

        public int Numero { get; set; }
        public string Texto { get; set; }

        public int AnoDe{ get; set; }

        public int AnoAte { get; set; }

        public int IdadeDe { get; set; }

        public int IdadeAte { get; set; }
    }
}
