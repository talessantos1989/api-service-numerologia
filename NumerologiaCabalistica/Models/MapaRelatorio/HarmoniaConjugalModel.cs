namespace NumerologiaCabalistica.Models.MapaRelatorio
{
    public class HarmoniaConjugalModel
    {
        public int CategoriaId { get { return 9; } }

        public int NumeroHarmoniaConjugal { get; set; }
        public string TextoHarmoniaConjugal { get; set; }

        public List<NumeroVibracao> NumeroVibracao { get; set; }

        public List<NumeroAtracao> NumeroAtracao { get; set; }

        public List<NumeroOposto> NumeroOposto { get; set; }

        public List<NumeroPassivo> NumeroPassivo { get; set; }

    }

    public class NumeroVibracao
    {
        public string Texto { get; set; }

        public int Numero { get; set; }
    }

    public class NumeroAtracao
    {
        public string Texto { get; set; }

        public int Numero { get; set; }
    }

    public class NumeroOposto
    {
        public string Texto { get; set; }

        public int Numero { get; set; }
    }

    public class NumeroPassivo
    {
        public string Texto { get; set; }

        public int Numero { get; set; }
    }

}
