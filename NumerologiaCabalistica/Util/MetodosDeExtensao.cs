using Microsoft.AspNetCore.WebUtilities;
using System.Linq;

namespace NumerologiaCabalistica.Util
{
    public static class MetodosDeExtensao
    {
        /// <summary>
        /// Dicionário de Letra e os valores numéricos correspondentes
        /// </summary>
        /// <returns>Dicionario de Letra e Valor de cada letra. Ex.: "A" : 1</returns>
        public static Dictionary<string, int> GetValoresTabelaConversao()
        {
            Dictionary<string, int> tabelaConversao = new Dictionary<string, int>
            {
                {"A", 1 },
                {"I", 1 },
                {"Q", 1 },
                {"J", 1 },
                {"Y", 1 },
                {"B", 2 },
                {"K", 2 },
                {"R", 2 },
                {"C", 3 },
                {"G", 3 },
                {"L", 3 },
                {"S", 3 },
                {"D", 4 },
                {"M", 4 },
                {"T", 4 },
                {"E", 5 },
                {"H", 5 },
                {"N", 5 },
                {"U", 6 },
                {"V", 6 },
                {"W", 6 },
                {"X", 6 },
                {"Ç", 6 },
                {"O", 7 },
                {"Z", 7 },
                {"F", 8 },
                {"P", 8 },

                {"Á", 3 },
                {"À", 2 },
                {"Ã", 4 },
                {"Â", 8 },
                {"Ä", 2 },
                {"Å", 8 },
                {"É", 7 },
                {"È", 1 },
                {"Ê", 3 },
                {"Í", 3 },
                {"Ì", 2 },
                {"Î", 8 },
                {"Ó", 9 },
                {"Ò", 5 },
                {"Õ", 1 },
                {"Ô", 5 },
                {"Ú", 8 },
                {"Ù", 3 },
                {"Û", 4 },

            };

            return tabelaConversao;

        }

        /// <summary>
        /// Monta a lista dos values da tabela de conversão do nome. Ex.: Ana => A = 1, N = 5, A = 1
        /// </summary>
        /// <param name="nomeCompleto">Nome da pessoa</param>
        /// <returns>Valor numérico das letras do nome</returns>
        public static List<int> GetValoresDoNome(string nomeCompleto)
        {
            var tabelaConversao = MetodosDeExtensao.GetValoresTabelaConversao();
            List<int> valoresDoNome = new List<int>();

            //pegar só as letras e valores correspondentes ao nome
            for (int i = 0; i < nomeCompleto.Length; i++)
            {
                int valor = 0;
                if (tabelaConversao.ContainsKey(nomeCompleto[i].ToString()))
                {
                    tabelaConversao.TryGetValue(nomeCompleto[i].ToString(), out valor);
                    valoresDoNome.Add(valor);
                }
            }
            return valoresDoNome;
        }

        /// <summary>
        /// Reduz um número para um unico algarismo. Ex: "55" -> 5 + 5 = 10 => 1 + 0 = 1
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Soma dos números reduzidos</returns>
        public static int ReduzirAUmAlgarismo(int numero, bool? reduzir11ou22 = true)
        {
            int dataReduzida = numero;
            while (dataReduzida.ToString().Length > 1)
            {
                int res = 0;
                List<string> data = new List<string>();
                for (int i = 0; i < dataReduzida.ToString().Length; i++)
                {
                    data.Add(dataReduzida.ToString()[i].ToString());
                }
                foreach (var item in data)
                {
                    res += Convert.ToInt32(item);
                }
                dataReduzida = res;
                if ((dataReduzida == 11 || dataReduzida == 22) && reduzir11ou22 == false)
                    return dataReduzida;
            }
           

            return dataReduzida;
        }

        /// <summary>
        /// Cria uma lista de vogais a partir
        /// </summary>
        /// <returns>Char com todas as vogais do alfabeto incluindo acentuação</returns>
        public static char[] GetVogais()
        {
           char[] vogais = {
                'A','E','I', 'O', 'U',
                'Á','À','Ã', 'Â',
                'É', 'È', 'Ê',
                'Í', 'Ì', 'Î',
                'Ó', 'Ò', 'Õ', 'Ô',
                'Ú', 'Ù', 'Û', 'Y'
            };

            return vogais;
        }

        /// <summary>
        /// Recupera todas as vogais de um nome (A, I, U)
        /// </summary>
        /// <param name="nomeCompleto">Nome completo</param>
        /// <returns>Uma lista de string com as vogais </returns>
        public static List<string> AcharVogais(string nomeCompleto)
        {
           
            List<string> vogaisNoNome = new List<string>();
            //Pegar as vogais
            char[] vogais = GetVogais();

            for (int i = 0; i < nomeCompleto.Length; i++)
            {
                if (vogais.Contains(nomeCompleto[i]))
                {
                    vogaisNoNome.Add(nomeCompleto[i].ToString());
                }
            }

            //achar o valor das vogais
            return vogaisNoNome;
        }


        /// <summary>
        /// Recupera todas as consoantes de um nome. Ex.: B, C, F
        /// </summary>
        /// <param name="nomeCompleto">Nome Completio</param>
        /// <returns>Uma lista de string com as consoantes </returns>
        public static List<string> AcharConsoantes(string nomeCompleto)
        {
            List<string> consoantesNoNome = new List<string>();
            char[] vogais = GetVogais();

            for (int i = 0; i < nomeCompleto.Length; i++)
            {
                if (!vogais.Contains(nomeCompleto[i]))
                {
                    consoantesNoNome.Add(nomeCompleto[i].ToString());
                }
            }
            return consoantesNoNome;
        }

        /// <summary>
        /// Soma a data completa e reduz a um unico algarismo. Ex.: 18/01/2019 = 1+8+0+1+2+0+1+9 = 22 = 2+2 = 4 
        /// </summary>
        /// <param name="dataNascimento">Data de nascimento</param>
        /// <returns>Soma reduzida a um único algarismo</returns>
        public static int SomarDataCompleta(DateTime dataNascimento)
        {
            int somaDestino = 0;

            int dia = dataNascimento.Day;
            int mes = dataNascimento.Month;
            int ano = dataNascimento.Year;

            int somaDia = dia % 10;
            int somaMes = mes % 10;
            int somaAno = ano % 10;

            somaDestino = ReduzirAUmAlgarismo(dia) + MetodosDeExtensao.ReduzirAUmAlgarismo(mes) + MetodosDeExtensao.ReduzirAUmAlgarismo(ano);
            return somaDestino;

        }

        /// <summary>
        /// Soma a data completa e reduz a um unico algarismo. Ex.: 18/01/2019 = 1+8+0+1+2+0+1+9 = 22 = 2+2 = 4.
        /// Método usando para para calcular o ano pessoa pois é utilizado o ano vigente
        /// </summary>
        /// <param name="dataNascimento">Data de Nascimento</param>
        /// <param name="anoVigente">Ano Atual</param>
        /// <returns>Soma reduzida a um unico algarismo</returns>
        public static int SomarDataCompleta(DateTime dataNascimento, int anoVigente)
        {
            int somaDestino = 0;

            int dia = dataNascimento.Day;
            int mes = dataNascimento.Month;
            int ano = anoVigente;

            int somaDia = dia % 10;
            int somaMes = mes % 10;
            int somaAno = ano % 10;

            somaDestino = ReduzirAUmAlgarismo(dia) + MetodosDeExtensao.ReduzirAUmAlgarismo(mes) + MetodosDeExtensao.ReduzirAUmAlgarismo(ano);
            return somaDestino;

        }
    }
}
