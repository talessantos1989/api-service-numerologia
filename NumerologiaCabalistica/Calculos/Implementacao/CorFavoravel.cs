using Microsoft.Net.Http.Headers;
using NumerologiaCabalistica.Models.MapaRelatorio;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    internal class CorFavoravel
    {
        private MapaModel _mapaModel;

        public CorFavoravel(MapaModel mapaModel)
        {
            this._mapaModel = mapaModel;
        }

        public CorFavoravelModel CalcularCorFavoravel()
        {
            CorFavoravelModel corFavoravel= new CorFavoravelModel();

            corFavoravel.Numero = _mapaModel.Expressao.Numero;

            switch (corFavoravel.Numero)
            {
                case 1:
                    corFavoravel.Texto = "Todos os tons de amarelo e laranja, castanho, dourado, verde, creme e branco.";
                    break;

                case 2:
                    corFavoravel.Texto = "Todos os tons de verde, creme, branco e cinza.";
                    break;

                case 3:
                    corFavoravel.Texto = "Violeta, vinho, púrpura e vermelha.";
                    break;

                case 4:
                    corFavoravel.Texto = "azul, cinza, púrpura e ouro.";
                    break;

                case 5:
                    corFavoravel.Texto = "todas as cores claras, cinza e prateado.";
                    break;

                case 6:
                    corFavoravel.Texto = "rosa, azul e verde.";
                    break;  

                case 7:
                    corFavoravel.Texto = "verde, amarelo, branco, cinza e azul-claro.";
                    break;

                case 8:
                    corFavoravel.Texto = "púrpura, cinza, azul, preto e castanho.";
                    break;

                case 9:
                    corFavoravel.Texto = "vermelho, rosa, coral e vinho.";
                    break;

                case 11:
                    corFavoravel.Texto = "branco, violeta e cores claras.";
                    break;

                case 22:
                    corFavoravel.Texto = "violeta, branco e cores claras.";
                    break;

                default:
                    break;
            }
            return corFavoravel;
        }
    }
}