using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    internal class TerceiroCicloDeVida
    {
        private ParametroCalculoNumerologia _parametrosCalculoNumerologia;
        private NumerologiaCabalisticaDbContext _context;
        private MapaModel _model;

        public TerceiroCicloDeVida(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext context, MapaModel model)
        {
            this._parametrosCalculoNumerologia = parametrosCalculoNumerologia;
            this._context = context;
            this._model = model;
        }

        public TerceiroCicloDeVidaModel CalcularTerceiroCicloDeVida()
        {
            TerceiroCicloDeVidaModel pCiclo = new TerceiroCicloDeVidaModel();
            pCiclo.Numero = MetodosDeExtensao.ReduzirAUmAlgarismo(_parametrosCalculoNumerologia.DataDeNascimento.Year);

            pCiclo.IdadeDe = _model.SegundoCicloDeVida.IdadeAte;
            pCiclo.AnoDe = _model.SegundoCicloDeVida.AnoAte;
            pCiclo.Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.Numero == pCiclo.Numero && texto.CategoriaId == pCiclo.CategoriaId).Texto;

            return pCiclo;

        }
    }
}