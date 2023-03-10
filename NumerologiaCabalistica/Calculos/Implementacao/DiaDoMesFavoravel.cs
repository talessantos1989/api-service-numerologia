using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.DiasMesFavoraveis;
using NumerologiaCabalistica.Models.MapaRelatorio;
using System.Security.Cryptography;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    internal class DiaDoMesFavoravel
    {
        private ParametroCalculoNumerologia _parametrosCalculoNumerologia;
        private NumerologiaCabalisticaDbContext _context;

        public DiaDoMesFavoravel(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext context)
        {
            this._parametrosCalculoNumerologia = parametrosCalculoNumerologia;
            this._context = context;
        }

        public List<DiasFavoraveisModel> CalcularDiaDoMesFavoravel()
        {
            List<DiasFavoraveisModel> model = new List<DiasFavoraveisModel>();

            //pega quais são os números favoraveis de acordo com o dia de nascimento e mes

            List<DiaDoMesFavoravelModel> dia = _context.DiasDoMesFavoraveis.Where(numero => numero.Dia == _parametrosCalculoNumerologia.DataDeNascimento.Day && numero.Mes.MesNumeral == _parametrosCalculoNumerologia.DataDeNascimento.Month).ToList();
            int contador = 1;
            //Faz enquanto o resultado for menor ou igual a 31
            int b = 0;
            int resultado = 0;
            for (int i = 0; i < 2; i++)
            {
                model.Add(new DiasFavoraveisModel
                {
                    Dia = dia[i].DiaFavoravel
                });
                contador++;
            }
            while (resultado <=31)
            {
                //passando pela terceira vez, dobrar o segundo numero favoravel
                if (contador == 3)
                {
                    resultado = model[1].Dia *2;
                    model.Add(new DiasFavoraveisModel { Dia = resultado });
                    contador++;

                }
                //
                else
                {
                    if (contador % 2 == 0) // é par
                        b = 0;
                    else b = 1;

                    resultado += dia[b].DiaFavoravel;
                    if (resultado <= 31) 
                        model.Add(new DiasFavoraveisModel { Dia = resultado });
                    contador++;
                }

            }
            return model;

        }
    }
}