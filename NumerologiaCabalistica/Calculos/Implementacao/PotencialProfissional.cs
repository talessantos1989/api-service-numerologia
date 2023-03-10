using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    internal class PotencialProfissional
    {
        private MapaModel _mapaModel;
        private NumerologiaCabalisticaDbContext _context;

        public PotencialProfissional(MapaModel mapaModel, NumerologiaCabalisticaDbContext context)
        {
            this._mapaModel = mapaModel;
            this._context = context;
        }

        public PotencialProfissionalModel CalcularPotencialProfissional()
        {
            PotencialProfissionalModel potencialProfissional = new PotencialProfissionalModel();

            var textos = _context.TextoNumerico.Where(texto => texto.CategoriaId == potencialProfissional.CategoriaId).ToList();

            potencialProfissional.Numero = _mapaModel.Expressao.Numero;
            potencialProfissional.Texto = textos.FirstOrDefault(texto => texto.Numero == potencialProfissional.Numero).Texto;

            return potencialProfissional;


        }
    }
}