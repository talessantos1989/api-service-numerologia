namespace NumerologiaCabalistica.Models.MapaRelatorio
{
    public class TrianguloDaVidaModel
    {
        public Arcano ArcanoAtual { get; set; }

        
        public List<Arcano> Arcanos { get; set; }
        

        public List<SequenciaNegativa> SequenciasNegativas { get; set; }


        public double PeriodoArcano { get; set; }


        public int ArcanoTrianguloDaVida { get; set; }


        public int Idade { get; set; }

        public int SequenciaNegativaCategoriaId { get { return 26; } }

        public int ArcanoCategoriaId { get { return 2; } }

        public int IdadeArcano { get; set; }



    }


    public class SequenciaNegativa
    {
        public int Numero { get; set; }

        public string Texto { get; set; }
    }
    public class Arcano
    {


        public int Numero { get; set; }

        public string Texto { get; set; }
    }
}
