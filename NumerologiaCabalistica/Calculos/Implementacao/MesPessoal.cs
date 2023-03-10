using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao;

public class MesPessoal
{
    private NumerologiaCabalisticaDbContext _context;
    private MapaModel _model;
    private ParametroCalculoNumerologia _parametros;

    public MesPessoal(ParametroCalculoNumerologia parametros, NumerologiaCabalisticaDbContext context, MapaModel model)
    {
        _parametros = parametros;
        _context = context;
        _model = model;
    }
    public MesPessoalModel GetMesPessoal()
    {
        MesPessoalModel mesPessoalModel = new MesPessoalModel();
        mesPessoalModel.MesesPessoais = new List<MesesPessoais>();


        //Data de nascimento com o ano atual
        DateTime dataNascimentoAnoAtual = new DateTime(DateTime.Now.Year, _parametros.DataDeNascimento.Month, _parametros.DataDeNascimento.Day); //22/12/22

        DateTime dataDe = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        DateTime dataAte = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

        int mesPessoal = 0;
        int count = 0;
        for (int i = 0; i < 13; i++)
        {

            //mês do aniversário
            if(dataDe.Month == dataNascimentoAnoAtual.Month)
            {
                if (count == 0)
                {
                    dataAte = new DateTime(dataAte.Year, dataAte.Month, dataNascimentoAnoAtual.AddDays(-1).Day);
                    var anoAtual = _model.AnoPessoal.AnosPessoais.FirstOrDefault(a => a.DataDe.Date <= dataDe.Date && a.DataAte >= dataAte.Date);
                    if (anoAtual != null)
                        mesPessoal = anoAtual.AnoPessoal + dataDe.Month;

                    else
                        mesPessoal = (_model.AnoPessoal.AnoPessoalAtual - 1) + dataDe.Month;

                    if (mesPessoal != 11 && mesPessoal != 22)
                        mesPessoal = MetodosDeExtensao.ReduzirAUmAlgarismo(mesPessoal);
                    mesPessoalModel.MesesPessoais.Add(new MesesPessoais
                    {
                        Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.Numero == mesPessoal && texto.CategoriaId == mesPessoalModel.CategoriaId).Texto,
                        Numero = mesPessoal,
                        MesDe = dataDe.Date.ToString("dd/MM/yyyy"),
                        MesAte = dataAte.Date.ToString("dd/MM/yyyy"),
                        MesExtenso = dataDe.ToString("MMMM")
                    });
                    count ++;
                }
                else if (count == 1)
                {
                    dataDe = dataAte.AddDays(1);
                    dataAte = new DateTime(dataDe.Year, dataDe.Month, DateTime.DaysInMonth(dataDe.Year, dataDe.Month));
                    if (dataDe.Date != dataAte.Date)
                    {
                        int anoAtual = _model.AnoPessoal.AnosPessoais.FirstOrDefault(a => a.DataDe.Date <= dataDe.Date && a.DataAte >= dataAte.Date).AnoPessoal;
                        mesPessoal = anoAtual + dataDe.Month;
                        if (mesPessoal != 11 && mesPessoal != 22)
                            mesPessoal = MetodosDeExtensao.ReduzirAUmAlgarismo(mesPessoal);
                        mesPessoalModel.MesesPessoais.Add(new MesesPessoais
                        {
                            Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.Numero == mesPessoal && texto.CategoriaId == mesPessoalModel.CategoriaId).Texto,
                            Numero = mesPessoal,
                            MesDe = dataDe.Date.ToString("dd/MM/yyyy"),
                            MesAte = dataAte.Date.ToString("dd/MM/yyyy"),
                            MesExtenso = dataDe.ToString("MMMM")
                        });
                    }
                    dataAte = dataAte.AddMonths(1);
                    dataDe = new DateTime(dataAte.Year, dataAte.Month, 1);
                }
            }
            else
            {
                int anoAtual = _model.AnoPessoal.AnosPessoais.FirstOrDefault(a => a.DataDe.Date <= dataDe.Date && a.DataAte >= dataAte.Date).AnoPessoal;
                mesPessoal = anoAtual + dataDe.Month;
                if (mesPessoal != 11 && mesPessoal != 22)
                    mesPessoal = MetodosDeExtensao.ReduzirAUmAlgarismo(mesPessoal);

                mesPessoalModel.MesesPessoais.Add(new MesesPessoais
                {
                    Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.Numero == mesPessoal && texto.CategoriaId == mesPessoalModel.CategoriaId).Texto,
                    Numero = mesPessoal,
                    MesDe = dataDe.Date.ToString("dd/MM/yyyy"),
                    MesAte = dataAte.Date.ToString("dd/MM/yyyy"),
                    MesExtenso = dataDe.ToString("MMMM")
                });
                dataDe = dataDe.AddMonths(1);
                dataAte = new DateTime(dataDe.Year, dataDe.Month, DateTime.DaysInMonth(dataDe.Year, dataDe.Month));
            }
           
            
        }
       
        return mesPessoalModel;

    }
}