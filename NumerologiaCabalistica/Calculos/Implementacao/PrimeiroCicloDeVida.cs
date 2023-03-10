using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    internal class PrimeiroCicloDeVida
    {
        private ParametroCalculoNumerologia _parametrosCalculoNumerologia;
        private NumerologiaCabalisticaDbContext _context;
        private MapaModel _model;

        public PrimeiroCicloDeVida(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext context, MapaModel model)
        {
            this._parametrosCalculoNumerologia = parametrosCalculoNumerologia;
            this._context = context;
            this._model = model;
        }

        public PrimeiroCicloDeVidaModel CalcularPrimeiroCicloDeVida()
        {
            PrimeiroCicloDeVidaModel pCiclo = new PrimeiroCicloDeVidaModel();
            pCiclo.Numero = _parametrosCalculoNumerologia.DataDeNascimento.Month;
            if (pCiclo.Numero != 11)
            {
                pCiclo.Numero = MetodosDeExtensao.ReduzirAUmAlgarismo(_parametrosCalculoNumerologia.DataDeNascimento.Month);
            }

            //37-11 = 26
            pCiclo.IdadeDe = 0;
            pCiclo.IdadeAte = 37 - _model.Destino.Numero;
            pCiclo.AnoDe = _parametrosCalculoNumerologia.DataDeNascimento.Year;
            pCiclo.AnoAte = _parametrosCalculoNumerologia.DataDeNascimento.Year + pCiclo.IdadeAte;
            pCiclo.Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.Numero == pCiclo.Numero && texto.CategoriaId == pCiclo.CategoriaId).Texto;

            return pCiclo;

        }
    }
}