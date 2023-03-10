using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    internal class NumeroHarmonico
    {
        private ParametroCalculoNumerologia _parametrosCalculoNumerologia;

        public NumeroHarmonico(ParametroCalculoNumerologia parametrosCalculoNumerologia)
        {
            this._parametrosCalculoNumerologia = parametrosCalculoNumerologia;
        }

        public NumeroHarmonicoModel CalcularNumeroHarmonico()
        {
            NumeroHarmonicoModel numeroHarmonicoModel= new NumeroHarmonicoModel();
            int diaNascimentoReduzido = MetodosDeExtensao.ReduzirAUmAlgarismo(_parametrosCalculoNumerologia.DataDeNascimento.Day);
            numeroHarmonicoModel.Numero = diaNascimentoReduzido;

            switch (diaNascimentoReduzido)
            {
                case 1:
                    numeroHarmonicoModel.NumerosHamonicos = new int[3] { 2, 4, 9 };
                    break;

                case 2:
                    numeroHarmonicoModel.NumerosHamonicos = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    break;

                case 3:
                    numeroHarmonicoModel.NumerosHamonicos = new int[5] { 2, 3, 6, 8, 9 };
                    break;

                case 4:
                    numeroHarmonicoModel.NumerosHamonicos = new int[4] { 1, 2, 6, 7 };
                    break;

                case 5:
                    numeroHarmonicoModel.NumerosHamonicos = new int[5] { 2, 5, 6, 7, 9 };
                    break;

                case 6:
                    numeroHarmonicoModel.NumerosHamonicos = new int[6] { 2, 3, 4, 5, 6, 9 };
                    break;

                case 7:
                    numeroHarmonicoModel.NumerosHamonicos = new int[4] { 2, 4, 5, 7 };
                    break;

                case 8:
                    numeroHarmonicoModel.NumerosHamonicos = new int[3] { 2, 3, 9 };
                    break;

                case 9:
                    numeroHarmonicoModel.NumerosHamonicos = new int[7] { 1, 2, 3, 5, 6, 8, 9 };
                    break;

                default:
                    break;
            }

            return numeroHarmonicoModel;
        }
    }
}