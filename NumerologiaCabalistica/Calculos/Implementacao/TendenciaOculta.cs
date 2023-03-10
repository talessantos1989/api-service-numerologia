using Microsoft.OpenApi.Models;
using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Models.TextosNumericos;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    public class TendenciaOculta
    {
        private readonly ParametroCalculoNumerologia _parametroCalculoNumerologia;
        private NumerologiaCabalisticaDbContext _context;

        public TendenciaOculta(ParametroCalculoNumerologia parametroCalculoNumerologia, NumerologiaCabalisticaDbContext context)
        {
            _parametroCalculoNumerologia = parametroCalculoNumerologia;
            _context = context;
        }

        public TendenciaOcultaModel GetTendenciaOculta()
        {
            
            TendenciaOcultaModel tendencia = new TendenciaOcultaModel();
            tendencia.TendenciasOcultas = new List<TendenciasOcultas>();

            var valoresDoNome = MetodosDeExtensao.GetValoresDoNome(_parametroCalculoNumerologia.NomeCompleto.ToUpper());
            List<TextoNumericoModel> textos = _context.TextoNumerico.Where(texto => texto.CategoriaId == tendencia.CategoriaId).ToList();

            var tendencias = valoresDoNome
                .GroupBy(x => x)
                .Where(g => g.Count() >= 4)
                .Select (x => x.Key) .ToList();

            if (tendencias != null)
            {
                foreach (var item in tendencias)
                {
                    tendencia.TendenciasOcultas.Add(new TendenciasOcultas
                    {
                        Numero = item,
                        Texto = textos.FirstOrDefault(texto => texto.Numero == item).Texto
                    });
                }
            }
            
                
            return tendencia;
        }
    }
}
