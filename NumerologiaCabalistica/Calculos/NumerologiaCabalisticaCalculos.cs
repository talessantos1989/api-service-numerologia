using Microsoft.EntityFrameworkCore;
using NumerologiaCabalistica.Calculos.Implementacao;
using NumerologiaCabalistica.Calculos.Interfaces;
using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.DiasMesFavoraveis;
using NumerologiaCabalistica.Models.MapaRelatorio;

namespace NumerologiaCabalistica.Calculos
{
    public class NumerologiaCabalisticaCalculos : INumerologiaCabalisticaCalculos
    {
        private NumerologiaCabalisticaDbContext _context;

        public NumerologiaCabalisticaCalculos(NumerologiaCabalisticaDbContext context)
        {
            this._context = context;   
        }


        public AnoPessoalModel GetAnoPessoal(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context)
        {
            return new AnoPessoal(parametrosCalculoNumerologia, _context).CalcularAnoPessoal(); 
        }

   

        public PrimeiroCicloDeVidaModel GetPrimeiroCicloDeVida(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model)
        {
            return new PrimeiroCicloDeVida(parametrosCalculoNumerologia, _context, model).CalcularPrimeiroCicloDeVida();
        }


        public DestinoModel GetDestino(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context)
        {
            return new Destino(parametrosCalculoNumerologia, _context).CalcularDestino();
        }


        public DiaNascimentoModel GetDiaNascimento(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context)
        {
            return new DiaNascimento(parametrosCalculoNumerologia, _context).CalcularDiaNatalicio();
        }

        public DiaPessoalModel GetDiaPessoal(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context)
        {
            return new DiaPessoal(parametrosCalculoNumerologia, _context).CalcularDiaPessoal();

        }

        public DividaCarmicaModel GetDividaCarmica(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model)
        {
            return new DividaCarmica(parametrosCalculoNumerologia, _context, model).GetDividaCarmica();
        }

        public ExpressaoModel GetExpressao(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context)
        {
            return new Expressao(parametrosCalculoNumerologia, _context).CalcularExpressao();
        }
        public ImpressaoModel GetImpressao(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context)
        {
            return new Impressao(parametrosCalculoNumerologia, _context).CalcularImpressao();
        }

        public LicaoCarmicaModel GetLicoesCarmicas(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context)
        {
            return new LicaoCarmica(parametrosCalculoNumerologia, _context).GetLicoesCarmicas();
        }

        public MesPessoalModel GetMesPessoal(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model)
        {
            return new MesPessoal(parametrosCalculoNumerologia, _context, model).GetMesPessoal();
        }

        public MissaoModel GetMissao(ParametroCalculoNumerologia parametrosCalculoNumerologia, MapaModel mapa, NumerologiaCabalisticaDbContext _context)
        {
            return new Missao(parametrosCalculoNumerologia, mapa, _context).CalcularMissao();
        }

        public MotivacaoModel GetMotivacao(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context)
        {
            return new Motivacao(parametrosCalculoNumerologia, _context).CalcularMotivacao();
        }

        public RespostaSubconscienteModel GetRespostaSubConsciente(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model)
        {
            return new RespostaSubConsciente(parametrosCalculoNumerologia, _context, model).CalcularRespostaSubConsciente();
        }

        public TendenciaOcultaModel GetTendenciasOcultas(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context)
        {
            return new TendenciaOculta(parametrosCalculoNumerologia, _context).GetTendenciaOculta();
        }

        public SegundoCicloDeVidaModel GetSegundoCicloDeVida(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model)
        {
            return new SegundoCicloDeVida(parametrosCalculoNumerologia, _context, model).CalcularPrimeiroCicloDeVida();
        }

        public TerceiroCicloDeVidaModel GetTerceiroCicloDeVida(ParametroCalculoNumerologia calculos, NumerologiaCabalisticaDbContext _context, MapaModel mapa)
        {
            return new TerceiroCicloDeVida(calculos, _context, mapa).CalcularTerceiroCicloDeVida();
        }

       
        public NumeroPsiquicoModel GetNumeroPsiquico(MapaModel mapa, NumerologiaCabalisticaDbContext _context)
        {
            return new NumeroPsiquico(mapa, _context).CalcularNumeroPsiquico();
        }

     

        public PrimeiroMomentoDecisivoModel GetPrimeiroMomentoDecisivo(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model)
        {
            return new PrimeiroMomentoDecisivo(parametrosCalculoNumerologia, _context, model).CalcularPrimeiroMomentoDecisivo();
        }

        public SegundoMomentoDecisivoModel GetSegundoMomentoDecisivo(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model)
        {
            return new SegundoMomentoDecisivo(parametrosCalculoNumerologia, _context, model).CalcularSegundoMomentoDecisivo();
        }

        public TerceiroMomentoDecisivoModel GetTerceiroMomentoDecisivo(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model)
        {
            return new TerceiroMomentoDecisivo(parametrosCalculoNumerologia, _context, model).CalcularTerceiroMomentoDecisivo();
        }

        public QuartoMomentoDecisivoModel GetQuartoMomentoDecisivo(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model)
        {
            return new QuartoMomentoDecisivo(parametrosCalculoNumerologia, _context, model).CalcularQuartoMomentoDecisivo();
        }
     

        public DesafioModel GetDesafio(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model)
        {
            return new Desafio(parametrosCalculoNumerologia, _context, model).CalcularDesafio();
        }

        public List<DiasFavoraveisModel> GetDiaFavoravel(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context)
        {
            return new DiaDoMesFavoravel(parametrosCalculoNumerologia, _context).CalcularDiaDoMesFavoravel();
        }

        public HarmoniaConjugalModel GetHarmoniaConjugal(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext context, MapaModel mapa)
        {
            return new HarmoniaConjugal(parametrosCalculoNumerologia, _context,  mapa).CalcularHarmoniaConjugal();
        }

        public NumeroHarmonicoModel GetNumerosHarmonicos(ParametroCalculoNumerologia parametrosCalculoNumerologia)
        {
            return new NumeroHarmonico(parametrosCalculoNumerologia).CalcularNumeroHarmonico();
        }

        public CorFavoravelModel GetCorFavoravel(MapaModel mapaModel)
        {
            return new CorFavoravel(mapaModel).CalcularCorFavoravel();
        }

        public PotencialProfissionalModel GetPotencialProfissional(MapaModel mapaModel, NumerologiaCabalisticaDbContext context)
        {
            return new PotencialProfissional(mapaModel, context).CalcularPotencialProfissional();
        }

        public TalentoOcultoModel GetTalentoOculto(NumerologiaCabalisticaDbContext context, MapaModel model)
        {
            return new TalentoOculto(model, context).CalcularTalentoOculto();
        }

        public TrianguloDaVidaModel GetTrianguloDaVida(ParametroCalculoNumerologia parametroCalculo, NumerologiaCabalisticaDbContext context)
        {
            return new TrianguloDaVida(parametroCalculo, context).CalcularTrianguloDaVida();
        }
    }
}
