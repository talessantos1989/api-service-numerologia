using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    internal class TalentoOculto
    {
        private NumerologiaCabalisticaDbContext _context;
        private MapaModel _model;

        public TalentoOculto(MapaModel model, NumerologiaCabalisticaDbContext context)
        {
            this._context = context;
            this._model = model;
        }

        public TalentoOcultoModel CalcularTalentoOculto()
        {
            TalentoOcultoModel talento = new TalentoOcultoModel();

            talento.Numero = MetodosDeExtensao.ReduzirAUmAlgarismo(_model.Expressao.Numero + _model.Motivacao.Numero, false);
            talento.Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.Numero == talento.Numero && texto.CategoriaId == talento.CategoriaId).Texto;

            return talento;
        }
    }
}