using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    internal class NumeroPsiquico
    {
        private MapaModel _model;
        private NumerologiaCabalisticaDbContext _context;

        public NumeroPsiquico(MapaModel model, NumerologiaCabalisticaDbContext context)
        {
            _model = model;
            _context = context;
        }

        public NumeroPsiquicoModel CalcularNumeroPsiquico()
        {
            NumeroPsiquicoModel numeroPsiquico = new NumeroPsiquicoModel();
            numeroPsiquico.Numero = MetodosDeExtensao.ReduzirAUmAlgarismo(_model.DiaNascimento.Numero);

            numeroPsiquico.Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.Numero == numeroPsiquico.Numero && texto.CategoriaId == numeroPsiquico.CategoriaId).Texto;

            return numeroPsiquico;
        }
    }
}