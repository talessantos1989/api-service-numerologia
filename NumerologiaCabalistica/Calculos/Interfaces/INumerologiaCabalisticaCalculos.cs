using Microsoft.EntityFrameworkCore;
using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.DiasMesFavoraveis;
using NumerologiaCabalistica.Models.MapaRelatorio;

namespace NumerologiaCabalistica.Calculos.Interfaces
{
    public interface INumerologiaCabalisticaCalculos
    {
        public MotivacaoModel GetMotivacao(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context);

        public DividaCarmicaModel GetDividaCarmica(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model);

        public ImpressaoModel GetImpressao(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context);
        
        public ExpressaoModel GetExpressao(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context);
        
        public DiaNascimentoModel GetDiaNascimento(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context);

        public TalentoOcultoModel GetTalentoOculto(NumerologiaCabalisticaDbContext _context, MapaModel model);
        
        public NumeroPsiquicoModel GetNumeroPsiquico(MapaModel mapa, NumerologiaCabalisticaDbContext _context);
        
        public DestinoModel GetDestino(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context);
        
        public MissaoModel GetMissao(ParametroCalculoNumerologia parametrosCalculoNumerologia, MapaModel mapa, NumerologiaCabalisticaDbContext _context);
        
        public LicaoCarmicaModel GetLicoesCarmicas(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context);
        
        public TendenciaOcultaModel GetTendenciasOcultas(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context);
        
        public RespostaSubconscienteModel GetRespostaSubConsciente(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model);
        
        public PrimeiroCicloDeVidaModel GetPrimeiroCicloDeVida(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model);

        public SegundoCicloDeVidaModel GetSegundoCicloDeVida(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model);

        public DesafioModel GetDesafio(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model);
        
        public PrimeiroMomentoDecisivoModel GetPrimeiroMomentoDecisivo(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model);

        public SegundoMomentoDecisivoModel GetSegundoMomentoDecisivo(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model);
        
        public TerceiroMomentoDecisivoModel GetTerceiroMomentoDecisivo(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model);
        
        public QuartoMomentoDecisivoModel GetQuartoMomentoDecisivo(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model);
        
        public AnoPessoalModel GetAnoPessoal(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context);
        
        public MesPessoalModel GetMesPessoal(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context, MapaModel model);
        
        public DiaPessoalModel GetDiaPessoal(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context);
        
        public List<DiasFavoraveisModel> GetDiaFavoravel(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext _context);
        
        public NumeroHarmonicoModel GetNumerosHarmonicos(ParametroCalculoNumerologia parametrosCalculoNumerologia);
       
        public TerceiroCicloDeVidaModel GetTerceiroCicloDeVida(ParametroCalculoNumerologia calculos, NumerologiaCabalisticaDbContext context, MapaModel mapa);

        public HarmoniaConjugalModel GetHarmoniaConjugal(ParametroCalculoNumerologia calculos, NumerologiaCabalisticaDbContext context, MapaModel mapa);
        
        public CorFavoravelModel GetCorFavoravel(MapaModel mapaModel);

        public PotencialProfissionalModel GetPotencialProfissional(MapaModel mapaModel, NumerologiaCabalisticaDbContext context);
        public TrianguloDaVidaModel GetTrianguloDaVida(ParametroCalculoNumerologia parametroCalculo, NumerologiaCabalisticaDbContext context);
    }

}

