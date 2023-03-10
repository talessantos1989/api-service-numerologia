using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;
using System.Reflection;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    public class Impressao
    {
        private ParametroCalculoNumerologia _model;
        private NumerologiaCabalisticaDbContext _context;
        public Impressao(ParametroCalculoNumerologia model, NumerologiaCabalisticaDbContext context)
        {
            _model = model;
            _context = context;    
        }

        public ImpressaoModel CalcularImpressao()
        {
            ImpressaoModel impressaoModel = new ImpressaoModel();
            List<string> consoantes = MetodosDeExtensao.AcharConsoantes(_model.NomeCompleto.ToUpper());
            Dictionary<string, int> tabelaDeConversao = MetodosDeExtensao.GetValoresTabelaConversao();
            int somaImpressao = 0;

            foreach (var consoante in consoantes)
            {
                if (tabelaDeConversao.ContainsKey(consoante))
                {
                    somaImpressao += tabelaDeConversao[consoante];
                }
            }

            impressaoModel.Numero = MetodosDeExtensao.ReduzirAUmAlgarismo(somaImpressao);

            impressaoModel.Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.Numero == impressaoModel.Numero && texto.CategoriaId == impressaoModel.NumeroCategoria).Texto;


            return impressaoModel;
        }
    }
}
