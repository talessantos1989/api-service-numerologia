using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    public class LicaoCarmica
    {
        private readonly ParametroCalculoNumerologia _parametroCalculoNumerologia;
        private NumerologiaCabalisticaDbContext _context;

        public LicaoCarmica(ParametroCalculoNumerologia parametroCalculoNumerologia, NumerologiaCabalisticaDbContext context)
        {
            _parametroCalculoNumerologia = parametroCalculoNumerologia;
            _context = context;
        }

        public LicaoCarmicaModel GetLicoesCarmicas()
        {
            LicaoCarmicaModel licaoCarmicaModel = new LicaoCarmicaModel();
            licaoCarmicaModel.LicoesCarmicas = new List<Licoes>();
            var valoresDoNome = MetodosDeExtensao.GetValoresDoNome(_parametroCalculoNumerologia.NomeCompleto.ToUpper());
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            valoresDoNome = valoresDoNome.Distinct().ToList();

            foreach (var item in numeros)
            {
                if (!valoresDoNome.Contains(item))
                {
                    licaoCarmicaModel.LicoesCarmicas.Add(
                        new Licoes
                        {
                            Numero = item,
                            Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.Numero == item && texto.CategoriaId == licaoCarmicaModel.NumeroCategoria).Texto
                        }
                        );
                }
            }
            return licaoCarmicaModel;
        }
    }
}
