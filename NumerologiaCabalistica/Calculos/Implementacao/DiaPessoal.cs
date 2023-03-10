using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Models.TextosNumericos;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    public class DiaPessoal
    {
        private ParametroCalculoNumerologia parametrosCalculoNumerologia;
        private NumerologiaCabalisticaDbContext context;

        public DiaPessoal(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext context)
        {
            this.parametrosCalculoNumerologia = parametrosCalculoNumerologia;
            this.context = context;
        }

        public DiaPessoalModel CalcularDiaPessoal()
        {
            DiaPessoalModel diaModel = new DiaPessoalModel();
            diaModel.DiasPessoais = new List<DiasPessoais>();
            List<TextoNumericoModel> diasPessoais = this.context.TextoNumerico.Where(texto => texto.CategoriaId == diaModel.CategoriaId).ToList();

            foreach (var item in diasPessoais)
            {
                diaModel.DiasPessoais.Add(new DiasPessoais 
                {
                    Numero = item.Numero,
                    Texto = item.Texto
                });
            }
            return diaModel;
        }
    }
}