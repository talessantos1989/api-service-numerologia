using NumerologiaCabalistica.Models.DiasMesFavoraveis;

namespace NumerologiaCabalistica.Models.MapaRelatorio
{
    public class MapaModel
    {
        public ExpressaoModel Expressao { get; set; }

        public ImpressaoModel Impressao { get; set; }

        public MotivacaoModel Motivacao { get; set; }

        public DiaNascimentoModel DiaNascimento { get; set; }

        public DestinoModel Destino { get; set; }

        public MissaoModel Missao { get; set; }
        
        public AnoPessoalModel AnoPessoal{ get; set; }

        public DividaCarmicaModel DividaCarmica { get; set; }
        
        public LicaoCarmicaModel LicaoCarmica { get; set; }
        
        public TendenciaOcultaModel TendenciaOculta { get; set; }

        public MesPessoalModel MesPessoal { get;  set; }

        public DiaPessoalModel DiaPessoal { get; set; }

        public RespostaSubconscienteModel RespostaSubconsciente { get; set; }

        public PrimeiroCicloDeVidaModel PrimeiroCicloDeVida { get;  set; }

        public SegundoCicloDeVidaModel SegundoCicloDeVida { get;  set; }

        public TerceiroCicloDeVidaModel TerceiroCicloDeVida { get; set; }

        public PrimeiroMomentoDecisivoModel PrimeiroMomentoDecisivo { get; set; }

        public SegundoMomentoDecisivoModel SegundoMomentoDecisivo { get; set; }

        public TerceiroMomentoDecisivoModel TerceiroMomentoDecisivo { get; set; }

        public QuartoMomentoDecisivoModel QuartoMomentoDecisivo { get; set; }
        
        public DesafioModel Desafio { get; set; }
        
        public List<DiasFavoraveisModel> DiasFavoraveis{ get; set; }


        public HarmoniaConjugalModel HarmoniaConjugal { get; set; }

        public NumeroHarmonicoModel NumeroHarmonico { get; set; }

        public CorFavoravelModel CorFavoravel { get; set; }

        public PotencialProfissionalModel PotencialProfissional{ get; set; }

        public TalentoOcultoModel TalentoOculto { get; set; }


        public NumeroPsiquicoModel NumeroPsiquico{ get; set; }


        public TrianguloDaVidaModel TrianguloDaVida { get; set; }

        public DateTime DataNascimento { get; set; }

        public string MapFile { get; set; }




    }
}
