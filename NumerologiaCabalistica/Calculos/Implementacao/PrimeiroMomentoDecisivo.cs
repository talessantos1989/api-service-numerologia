using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Models.TextosNumericos;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    internal class PrimeiroMomentoDecisivo
    {
        private ParametroCalculoNumerologia _parametrosCalculoNumerologia;
        private NumerologiaCabalisticaDbContext _context;
        private MapaModel _model;

        public PrimeiroMomentoDecisivo(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext context, MapaModel model)
        {
            this._parametrosCalculoNumerologia = parametrosCalculoNumerologia;
            this._context = context;
            this._model = model;
        }

        public PrimeiroMomentoDecisivoModel CalcularPrimeiroMomentoDecisivo()
        {
            PrimeiroMomentoDecisivoModel primeiroMD = new PrimeiroMomentoDecisivoModel();
            primeiroMD.AnoDe = _model.PrimeiroCicloDeVida.AnoDe;
            primeiroMD.AnoAte = _model.PrimeiroCicloDeVida.AnoAte;
            primeiroMD.IdadeDe = _model.PrimeiroCicloDeVida.IdadeDe;
            primeiroMD.IdadeAte = _model.PrimeiroCicloDeVida.IdadeAte;

            List<TextoNumericoModel> textos = _context.TextoNumerico.Where(texto => texto.CategoriaId == primeiroMD.CategoriaId).ToList();

            int primeiroMomentoDecisivo = MetodosDeExtensao.ReduzirAUmAlgarismo(_parametrosCalculoNumerologia.DataDeNascimento.Day + _parametrosCalculoNumerologia.DataDeNascimento.Month);

            
            primeiroMD.Texto = textos.FirstOrDefault(x => x.Numero == primeiroMomentoDecisivo).Texto;
            primeiroMD.Numero = primeiroMomentoDecisivo;   
            return primeiroMD;
        }
    }
}