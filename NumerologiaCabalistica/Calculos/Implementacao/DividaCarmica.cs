using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    public class DividaCarmica
    {
        private readonly ParametroCalculoNumerologia _parametroCalculoNumerologia;
        private NumerologiaCabalisticaDbContext _context;
        private MapaModel _model;
        public DividaCarmica(ParametroCalculoNumerologia parametroCalculoNumerologia, NumerologiaCabalisticaDbContext context, MapaModel model)
        {
            _parametroCalculoNumerologia = parametroCalculoNumerologia;
            _context = context;
            _model = model;
        }

        public DividaCarmicaModel GetDividaCarmica()
        {
            DividaCarmicaModel divida = new DividaCarmicaModel();
            divida.DividasCarmicas = new List<Dividas>();
            List<int> numeroDividasCarmicas = new List<int>();
            int diaNascimento = _parametroCalculoNumerologia.DataDeNascimento.Day;
            if (diaNascimento == 13 || diaNascimento == 14 || diaNascimento == 16 || diaNascimento == 19)
            {
                numeroDividasCarmicas.Add(diaNascimento);
            }

            switch (_model.Expressao.Numero)
            {
                case 4:
                    numeroDividasCarmicas.Add(13);
                    break;

                case 5:
                    numeroDividasCarmicas.Add(14);
                    break;

                case 7:
                    numeroDividasCarmicas.Add(16);
                    break;

                case 1:
                    numeroDividasCarmicas.Add(19);
                    break;
                default:
                    break;
            }

            switch (_model.Destino.Numero)
            {
                case 4:
                    numeroDividasCarmicas.Add(13);
                    break;

                case 5:
                    numeroDividasCarmicas.Add(14);
                    break;

                case 7:
                    numeroDividasCarmicas.Add(16);
                    break;

                case 1:
                    numeroDividasCarmicas.Add(19);
                    break;
                default:
                    break;
            }

            switch (_model.Motivacao.Numero)
            {
                case 4:
                    numeroDividasCarmicas.Add(13);
                    break;

                case 5:
                    numeroDividasCarmicas.Add(14);
                    break;

                case 7:
                    numeroDividasCarmicas.Add(16);
                    break;

                case 1:
                    numeroDividasCarmicas.Add(19);
                    break;
                default:
                    break;
            }

            if (numeroDividasCarmicas.Count > 0)
            {
                foreach (var item in numeroDividasCarmicas)
                {
                    var textodivida = _context.TextoNumerico.FirstOrDefault(texto=> texto.Numero == item && texto.CategoriaId == divida.NumeroCategoria).Texto;
                    divida.DividasCarmicas.Add(new Dividas { Numero = item, Texto = textodivida });
                }
            }
            return divida;  
        }
    }
}
