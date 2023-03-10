using NumerologiaCabalistica.Data;

namespace NumerologiaCabalistica.Models.MapaRelatorio
{
    public class DesafioModel
    {

        public int CategoriaId
        {
            get
            {
                return 4;
            }
        }

        public PrimeiroDesafio PrimeiroDesafio { get; set; }

        public SegundoDesafio SegundoDesafio { get; set; }

        public TerceiroDesafio TerceiroDesafio { get; set; }
    }

    public class PrimeiroDesafio : Desafios
    {
       
    }

    public class SegundoDesafio : Desafios
    {
       
    }

    public class TerceiroDesafio : Desafios
    {
        
    }

    public class Desafios
    {
        public int Numero { get; set; }
        public string Texto { get; set; }

        public int AnoDe { get; set; }

        public int AnoAte { get; set; }

        public int IdadeDe { get; set; }

        public int IdadeAte { get; set; }
    }

}
