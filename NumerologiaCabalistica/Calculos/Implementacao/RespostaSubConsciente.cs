using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    internal class RespostaSubConsciente
    {
        private ParametroCalculoNumerologia _parametrosCalculoNumerologia;
        private NumerologiaCabalisticaDbContext _context;
        private MapaModel _model;

        public RespostaSubConsciente(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext context, MapaModel model)
        {
            this._parametrosCalculoNumerologia = parametrosCalculoNumerologia;
            this._context = context;
            this._model = model;
        }

        public RespostaSubconscienteModel CalcularRespostaSubConsciente()
        {
            RespostaSubconscienteModel subConscienteModel = new RespostaSubconscienteModel();

            subConscienteModel.Numero = 9 - _model.LicaoCarmica.LicoesCarmicas.Count;
            subConscienteModel.Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.Numero == subConscienteModel.Numero && texto.CategoriaId == subConscienteModel.CategoriaId).Texto;
            return subConscienteModel;

        }
    }
}