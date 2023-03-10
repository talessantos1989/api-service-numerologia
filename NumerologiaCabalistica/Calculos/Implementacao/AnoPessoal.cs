using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Models.TextosNumericos;
using NumerologiaCabalistica.Util;
using System.Data;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    public class AnoPessoal
    {
        private readonly ParametroCalculoNumerologia _model;
        private NumerologiaCabalisticaDbContext _context;
        public AnoPessoal(ParametroCalculoNumerologia model, NumerologiaCabalisticaDbContext context)
        {
            _model = model;
            _context = context;
        }

        public AnoPessoalModel CalcularAnoPessoal()
        {
            AnoPessoalModel model = new AnoPessoalModel();
            model.AnosPessoais = new List<AnosPessoais>();
            DateTime dataAtual = DateTime.Now; 

            //Preenche a data de nascimento com o ano atual
            DateTime dataNascimento = new DateTime(dataAtual.Year, _model.DataDeNascimento.Month, _model.DataDeNascimento.Day);

            //Verifica se a pessoa já fez aniversario
            int aniversario = DateTime.Compare(dataAtual, dataNascimento);


            //Se ainda não fez, faz o calculo usando o ano do último aniversário. Se já fez aniversário, faz o cálculo com o ano atual vigente
            var dataReduzida = aniversario < 0 
                ? MetodosDeExtensao.SomarDataCompleta(_model.DataDeNascimento, DateTime.Now.AddYears(-1).Year)
                : MetodosDeExtensao.SomarDataCompleta(_model.DataDeNascimento, DateTime.Now.Year);


            //reduz a um unico algarismo a data
            dataReduzida = MetodosDeExtensao.ReduzirAUmAlgarismo(dataReduzida);

            //preenche a model com o ano atual
            model.AnoPessoalAtual = dataReduzida; 

            List<TextoNumericoModel> textos = _context.TextoNumerico.Where(categoria => categoria.CategoriaId == model.CategoriaId).ToList();


            for (int i = 0; i < textos.Count; i++)
            {
                if (DateTime.Compare(dataAtual, dataNascimento) < 0)
                {
                    dataNascimento = dataNascimento.AddYears(-1);
                }
                model.AnosPessoais.Add(new AnosPessoais
                {
                    Texto = textos[dataReduzida - 1].Texto,
                    AnoPessoal = dataReduzida,
                    DataDe = dataNascimento,
                    DataAte = dataNascimento.AddYears(1).AddDays(-1),
                });
                int anoAnterior = dataNascimento.Year;
                int dataReduzidaAnterior = dataReduzida - 1;
                if (dataReduzida == 9)
                {
                    dataReduzida = dataReduzida - dataReduzidaAnterior;
                }
                else
                {
                    dataReduzida++;
                }
                dataNascimento = new DateTime(anoAnterior + 1, _model.DataDeNascimento.Month, _model.DataDeNascimento.Day);
                dataAtual = dataAtual.AddYears(1);
            }


            return model;
        }


    }
}
