using NumerologiaCabalistica.Calculos.Interfaces;
using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    public class Expressao
    {
        private readonly ParametroCalculoNumerologia _model;
        private NumerologiaCabalisticaDbContext _context;
        public Expressao(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext context)
        {
            _model = parametrosCalculoNumerologia;
            _context = context;
        }

        public ExpressaoModel CalcularExpressao()
        {
            var tabelaDeConversao = MetodosDeExtensao.GetValoresTabelaConversao();
            ExpressaoModel expressao = new ExpressaoModel();
            string nomeCompleto = _model.NomeCompleto.ToUpper();
            int somaExpressao = 0;
            List<int> listaNomesSeparados = new List<int>();
            string[] nomeSeparado = nomeCompleto.Split(' ');

            int somaNomeCompleto = 0;

            foreach (var item in nomeSeparado)
            {
                int somaNomeSeparado = 0;
                foreach (var letra in item)
                {
                    somaNomeSeparado += tabelaDeConversao[letra.ToString()];
                }
                listaNomesSeparados.Add(MetodosDeExtensao.ReduzirAUmAlgarismo(somaNomeSeparado));
            }

            foreach (var item in listaNomesSeparados)
            {
                somaExpressao += item;
            }

            if (somaExpressao != 22 && expressao.Numero != 11)
            {
                somaExpressao = MetodosDeExtensao.ReduzirAUmAlgarismo(somaExpressao, false);
            }
         
            expressao.Numero = somaExpressao;

            expressao.Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.Numero == expressao.Numero && texto.CategoriaId == expressao.NumeroCategoria).Texto;


            return expressao;
        }
    }
}
