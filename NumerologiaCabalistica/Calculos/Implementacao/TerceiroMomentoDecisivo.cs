using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    internal class TerceiroMomentoDecisivo
    {
        private ParametroCalculoNumerologia _parametrosCalculoNumerologia;
        private NumerologiaCabalisticaDbContext _context;
        private MapaModel _model;

        public TerceiroMomentoDecisivo(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext context, MapaModel model)
        {
            this._parametrosCalculoNumerologia = parametrosCalculoNumerologia;
            this._context = context;
            this._model = model;
        }

        public TerceiroMomentoDecisivoModel CalcularTerceiroMomentoDecisivo()
        {
            TerceiroMomentoDecisivoModel terceiroMD = new TerceiroMomentoDecisivoModel();

            int terceiroMomento = _model.PrimeiroMomentoDecisivo.Numero + _model.SegundoMomentoDecisivo.Numero;
            if (terceiroMomento != 11)
                terceiroMomento = MetodosDeExtensao.ReduzirAUmAlgarismo(terceiroMomento);

            terceiroMD.Texto = _context.TextoNumerico.FirstOrDefault(x => x.Numero == terceiroMomento && x.CategoriaId == terceiroMD.CategoriaId).Texto;
            terceiroMD.AnoDe = _model.SegundoMomentoDecisivo.AnoAte;
            terceiroMD.AnoAte = terceiroMD.AnoDe + 9;
            terceiroMD.IdadeDe = _model.SegundoMomentoDecisivo.IdadeAte;
            terceiroMD.IdadeAte = terceiroMD.IdadeDe + 9;
            terceiroMD.Numero = terceiroMomento;

            return terceiroMD;
        }
    }
}