using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NumerologiaCabalistica.Calculos.Interfaces;
using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Data.DTO.CalculoCabalistico;
using NumerologiaCabalistica.Data.DTO.MapaModel;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.PDF;
using NumerologiaCabalistica.Repository;

namespace NumerologiaCabalistica.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalculoCabalisticoController : ControllerBase
{
    private readonly INumerologiaCabalisticaCalculos _numerologiaCabalisticaCalculos;
    private IMapper _mapper;
    private NumerologiaCabalisticaDbContext _context;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="numerologiaCabalisticaCalculos"></param>
    /// <param name="mapper"></param>
    /// <param name="context"></param>
    public CalculoCabalisticoController(INumerologiaCabalisticaCalculos numerologiaCabalisticaCalculos, IMapper mapper, NumerologiaCabalisticaDbContext context)
    {
        _numerologiaCabalisticaCalculos = numerologiaCabalisticaCalculos;
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public IActionResult RecuperarNumerologiaCabalistica([FromBody] ReadParametroCalculoNumerologiaDTO parametros)
    {

        Console.WriteLine(parametros.ToString());

        MapaModel mapa = new MapaModel();

        mapa.DataNascimento = parametros.DataDeNascimento;

        var parametroCalculo = _mapper.Map<ParametroCalculoNumerologia>(parametros);


        mapa.Motivacao = _numerologiaCabalisticaCalculos.GetMotivacao(parametroCalculo, _context);
        
      
        mapa.Impressao = _numerologiaCabalisticaCalculos.GetImpressao(parametroCalculo, _context);

        
        mapa.Expressao = _numerologiaCabalisticaCalculos.GetExpressao(parametroCalculo, _context);

        
        mapa.DiaNascimento = _numerologiaCabalisticaCalculos.GetDiaNascimento(parametroCalculo, _context);


        mapa.Destino = _numerologiaCabalisticaCalculos.GetDestino(parametroCalculo, _context);
        

        mapa.Missao = _numerologiaCabalisticaCalculos.GetMissao(parametroCalculo, mapa, _context);


        mapa.DividaCarmica = _numerologiaCabalisticaCalculos.GetDividaCarmica(parametroCalculo, _context, mapa);


        mapa.LicaoCarmica = _numerologiaCabalisticaCalculos.GetLicoesCarmicas(parametroCalculo, _context);


        mapa.TendenciaOculta = _numerologiaCabalisticaCalculos.GetTendenciasOcultas(parametroCalculo, _context);


        mapa.AnoPessoal = _numerologiaCabalisticaCalculos.GetAnoPessoal(parametroCalculo, _context);


        mapa.MesPessoal= _numerologiaCabalisticaCalculos.GetMesPessoal(parametroCalculo, _context, mapa);


        mapa.DiaPessoal = _numerologiaCabalisticaCalculos.GetDiaPessoal(parametroCalculo, _context);


        mapa.RespostaSubconsciente = _numerologiaCabalisticaCalculos.GetRespostaSubConsciente(parametroCalculo, _context, mapa);


        mapa.PrimeiroCicloDeVida = _numerologiaCabalisticaCalculos.GetPrimeiroCicloDeVida(parametroCalculo, _context, mapa);


        mapa.SegundoCicloDeVida = _numerologiaCabalisticaCalculos.GetSegundoCicloDeVida(parametroCalculo, _context, mapa);


        mapa.TerceiroCicloDeVida = _numerologiaCabalisticaCalculos.GetTerceiroCicloDeVida(parametroCalculo, _context, mapa);


        mapa.PrimeiroMomentoDecisivo = _numerologiaCabalisticaCalculos.GetPrimeiroMomentoDecisivo(parametroCalculo, _context, mapa);


        mapa.SegundoMomentoDecisivo = _numerologiaCabalisticaCalculos.GetSegundoMomentoDecisivo(parametroCalculo, _context, mapa);


        mapa.TerceiroMomentoDecisivo = _numerologiaCabalisticaCalculos.GetTerceiroMomentoDecisivo(parametroCalculo, _context, mapa);


        mapa.QuartoMomentoDecisivo = _numerologiaCabalisticaCalculos.GetQuartoMomentoDecisivo(parametroCalculo, _context, mapa);

        
        mapa.Desafio = _numerologiaCabalisticaCalculos.GetDesafio(parametroCalculo, _context, mapa);


        mapa.DiasFavoraveis = _numerologiaCabalisticaCalculos.GetDiaFavoravel(parametroCalculo, _context);

        
        mapa.HarmoniaConjugal = _numerologiaCabalisticaCalculos.GetHarmoniaConjugal(parametroCalculo, _context, mapa);


        mapa.NumeroHarmonico = _numerologiaCabalisticaCalculos.GetNumerosHarmonicos(parametroCalculo);


        mapa.CorFavoravel = _numerologiaCabalisticaCalculos.GetCorFavoravel(mapa);


        mapa.PotencialProfissional = _numerologiaCabalisticaCalculos.GetPotencialProfissional(mapa, _context);


        mapa.TalentoOculto = _numerologiaCabalisticaCalculos.GetTalentoOculto(_context, mapa);


        mapa.NumeroPsiquico = _numerologiaCabalisticaCalculos.GetNumeroPsiquico(mapa, _context);

        mapa.TrianguloDaVida = _numerologiaCabalisticaCalculos.GetTrianguloDaVida(parametroCalculo, _context);

        
        
        mapa.MapFile = GeradorDePDF.GerarPDF(mapa, parametroCalculo.NomeCompleto);


        var mapaDTO = _mapper.Map<ReadMapaDTO>(mapa);

        return Ok(mapaDTO);
    }
   
}
