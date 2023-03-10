using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    internal class SegundoMomentoDecisivo
    {
        private ParametroCalculoNumerologia _parametrosCalculoNumerologia;
        private NumerologiaCabalisticaDbContext _context;
        private MapaModel _model;

        public SegundoMomentoDecisivo(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext context, MapaModel model)
        {
            this._parametrosCalculoNumerologia = parametrosCalculoNumerologia;
            this._context = context;
            this._model = model;
        }

        public SegundoMomentoDecisivoModel CalcularSegundoMomentoDecisivo()
        {
            SegundoMomentoDecisivoModel segundoMD = new SegundoMomentoDecisivoModel();
            int somaDia = MetodosDeExtensao.ReduzirAUmAlgarismo(_parametrosCalculoNumerologia.DataDeNascimento.Day); 
            int somaAno = MetodosDeExtensao.ReduzirAUmAlgarismo(_parametrosCalculoNumerologia.DataDeNascimento.Year);
            int segundoMomento = somaDia + somaAno;
            
            if (segundoMomento != 11) segundoMomento = MetodosDeExtensao.ReduzirAUmAlgarismo(segundoMomento);

            segundoMD.Numero = segundoMomento;
            segundoMD.AnoDe = _model.SegundoCicloDeVida.AnoDe;
            segundoMD.AnoAte = segundoMD.AnoDe + 9;
            segundoMD.IdadeDe = _model.SegundoCicloDeVida.IdadeDe;
            segundoMD.IdadeAte = segundoMD.IdadeDe + 9;
            segundoMD.Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.CategoriaId == segundoMD.CategoriaId && texto.Numero == segundoMomento).Texto;

            return segundoMD;
        }
    }
}