using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    internal class SegundoCicloDeVida
    {
        private ParametroCalculoNumerologia _parametrosCalculoNumerologia;
        private NumerologiaCabalisticaDbContext _context;
        private MapaModel _model;

        public SegundoCicloDeVida(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext context, MapaModel model)
        {
            this._parametrosCalculoNumerologia = parametrosCalculoNumerologia;
            this._context = context;
            this._model = model;
        }

        public SegundoCicloDeVidaModel CalcularPrimeiroCicloDeVida()
        {
            SegundoCicloDeVidaModel pCiclo = new SegundoCicloDeVidaModel();
            pCiclo.Numero = MetodosDeExtensao.ReduzirAUmAlgarismo(_parametrosCalculoNumerologia.DataDeNascimento.Day);

            //37-11 = 26
            pCiclo.IdadeDe = _model.PrimeiroCicloDeVida.IdadeAte;
            pCiclo.IdadeAte = pCiclo.IdadeDe + 27;
            pCiclo.AnoDe = _model.PrimeiroCicloDeVida.AnoAte;
            pCiclo.AnoAte = pCiclo.AnoDe + 27;
            pCiclo.Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.Numero == pCiclo.Numero && texto.CategoriaId == pCiclo.CategoriaId).Texto;

            return pCiclo;

        }
    }
}