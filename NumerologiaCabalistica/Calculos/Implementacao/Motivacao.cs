using Microsoft.EntityFrameworkCore;
using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Models.TextosNumericos;
using NumerologiaCabalistica.Util;
using System.Reflection;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    public class Motivacao
    {
        private ParametroCalculoNumerologia _model;
        private NumerologiaCabalisticaDbContext _context;

        public Motivacao(ParametroCalculoNumerologia model, NumerologiaCabalisticaDbContext context)
        {
            _model = model;
            _context = context;
        }

        public MotivacaoModel CalcularMotivacao()
        {
            MotivacaoModel motivacaoModel = new MotivacaoModel();
            List<string> vogais = MetodosDeExtensao.AcharVogais(_model.NomeCompleto.ToUpper());
            Dictionary<string, int> tabelaDeConversao = MetodosDeExtensao.GetValoresTabelaConversao();
            int somaMotivacao = 0;
            int numeroMotivacao = 0;

            foreach (var vogal in vogais)
            {
                if (tabelaDeConversao.ContainsKey(vogal))
                {
                    somaMotivacao += tabelaDeConversao[vogal];
                }
            }

            //Não reduz 
            if (somaMotivacao != 22 && somaMotivacao != 11)
            {
                numeroMotivacao = MetodosDeExtensao.ReduzirAUmAlgarismo(somaMotivacao);
                motivacaoModel.Numero = numeroMotivacao;

            }
            else
                motivacaoModel.Numero = somaMotivacao;

            motivacaoModel.Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.Numero == motivacaoModel.Numero && texto.CategoriaId == motivacaoModel.NumeroCategoria).Texto;



            return motivacaoModel;
        }
    }
}
