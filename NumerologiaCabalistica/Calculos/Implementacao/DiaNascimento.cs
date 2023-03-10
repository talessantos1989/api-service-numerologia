using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using System.Diagnostics;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    public class DiaNascimento
    {
        private readonly ParametroCalculoNumerologia _model;
        private NumerologiaCabalisticaDbContext _context;
        public DiaNascimento(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext context)
        {
            _model = parametrosCalculoNumerologia;
            _context = context;
        }


        public DiaNascimentoModel CalcularDiaNatalicio()
        {
            DiaNascimentoModel diaNascimento = new DiaNascimentoModel();

            int dia = _model.DataDeNascimento.Day;
            diaNascimento.Numero = dia;

            diaNascimento.Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.Numero == dia && texto.CategoriaId == diaNascimento.NumeroCategoria).Texto;
            return diaNascimento;
        }
    }
}
