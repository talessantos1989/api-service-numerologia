using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    internal class QuartoMomentoDecisivo
    {
        private ParametroCalculoNumerologia _parametrosCalculoNumerologia;
        private NumerologiaCabalisticaDbContext _context;
        private MapaModel _model;

        public QuartoMomentoDecisivo(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext context, MapaModel model)
        {
            this._parametrosCalculoNumerologia = parametrosCalculoNumerologia;
            this._context = context;
            this._model = model;
        }

        public QuartoMomentoDecisivoModel CalcularQuartoMomentoDecisivo()
        {
            QuartoMomentoDecisivoModel quartoMD = new QuartoMomentoDecisivoModel();
            int somaMes = MetodosDeExtensao.ReduzirAUmAlgarismo(_parametrosCalculoNumerologia.DataDeNascimento.Month);
            int somaAno = MetodosDeExtensao.ReduzirAUmAlgarismo(_parametrosCalculoNumerologia.DataDeNascimento.Year);

            int somaQuartoMomento = somaMes + somaAno;

            if (somaQuartoMomento != 11) somaQuartoMomento = MetodosDeExtensao.ReduzirAUmAlgarismo(somaQuartoMomento);

            quartoMD.Numero = somaQuartoMomento;
            quartoMD.IdadeDe = _model.TerceiroMomentoDecisivo.IdadeAte;
            quartoMD.AnoDe = _model.TerceiroMomentoDecisivo.AnoAte;
            quartoMD.AnoAte = string.Empty;

            quartoMD.Texto = _context.TextoNumerico.FirstOrDefault(x => x.CategoriaId == quartoMD.CategoriaId && x.Numero == somaQuartoMomento).Texto;

            return quartoMD;
        }
    }
}