using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    internal class HarmoniaConjugal
    {
        private ParametroCalculoNumerologia _parametrosCalculoNumerologia;
        private NumerologiaCabalisticaDbContext _context;
        private MapaModel _mapaModel;

        public HarmoniaConjugal(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext context, MapaModel mapaModel)
        {
            this._parametrosCalculoNumerologia = parametrosCalculoNumerologia;
            this._context = context;
            this._mapaModel = mapaModel;
        }

        public HarmoniaConjugalModel CalcularHarmoniaConjugal()
        {
            HarmoniaConjugalModel harmoniaConjugal = new HarmoniaConjugalModel();
            var textosDoAmor = _context.TextoNumerico.Where(texto => texto.CategoriaId == harmoniaConjugal.CategoriaId).ToList();

            harmoniaConjugal.NumeroHarmoniaConjugal = MetodosDeExtensao.ReduzirAUmAlgarismo(_mapaModel.Missao.Numero);
            harmoniaConjugal.TextoHarmoniaConjugal = textosDoAmor.FirstOrDefault(txto => txto.Numero == harmoniaConjugal.NumeroHarmoniaConjugal).Texto;

            harmoniaConjugal.NumeroAtracao = new List<NumeroAtracao>();
            harmoniaConjugal.NumeroVibracao = new List<NumeroVibracao>();
            harmoniaConjugal.NumeroPassivo = new List<NumeroPassivo>();
            harmoniaConjugal.NumeroOposto = new List<NumeroOposto>();



            switch (harmoniaConjugal.NumeroHarmoniaConjugal)
            {
                case 1:
                    harmoniaConjugal.NumeroVibracao.Add(new NumeroVibracao  { Numero = 9, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 9).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 4, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 4).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 8, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 8).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 6, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 6).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 7, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 7).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 2, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 2).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 3, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 3).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 5, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 5).Texto });
                    break;

                case 2:
                    harmoniaConjugal.NumeroVibracao.Add(new NumeroVibracao  { Numero = 8, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 8).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 7, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 7).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 9, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 9).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 5, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 5).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 1, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 1).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 3, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 3).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 4, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 4).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 6, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 6).Texto });
                    break;

                case 3:
                    harmoniaConjugal.NumeroVibracao.Add(new NumeroVibracao  { Numero = 7, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 7).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 5, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 5).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 6, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 6).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 9, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 9).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 4, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 4).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 8, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 8).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 1, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 1).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 2, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 2).Texto });
                    break;


                case 4:
                    harmoniaConjugal.NumeroVibracao.Add(new NumeroVibracao  { Numero = 6, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 6).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 1, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 1).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 8, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 8).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 3, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 3).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 5, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 5).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 2, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 2).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 7, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 7).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 9, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 9).Texto });
                    break;


                case 5:
                    harmoniaConjugal.NumeroVibracao.Add(new NumeroVibracao  { Numero = 5, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 5).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 3, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 3).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 9, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 9).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 2, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 2).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 4, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 4).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 6, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 6).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 1, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 1).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 7, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 7).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 8, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 8).Texto });
                    break;

                case 6:
                    harmoniaConjugal.NumeroVibracao.Add(new NumeroVibracao  { Numero = 4, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 4).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 3, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 3).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 7, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 7).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 9, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 9).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 1, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 1).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 8, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 8).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 5, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 5).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 2, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 2).Texto });
                    break;

                case 7:
                    harmoniaConjugal.NumeroVibracao.Add(new NumeroVibracao  { Numero = 3, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 3).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 2, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 2).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 6, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 6).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 1, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 1).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 9, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 9).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 4, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 4).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 5, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 5).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 8, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 8).Texto });
                    break;

                case 8:
                    harmoniaConjugal.NumeroVibracao.Add(new NumeroVibracao  { Numero = 2, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 2).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 1, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 1).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 4, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 4).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 3, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 3).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 6, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 6).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 5, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 5).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 7, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 7).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 9, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 9).Texto });
                    break;

                case 9:
                    harmoniaConjugal.NumeroVibracao.Add(new NumeroVibracao  { Numero = 1, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 1).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 2, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 2).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 3, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 3).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 5, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 5).Texto });
                    harmoniaConjugal.NumeroAtracao. Add(new NumeroAtracao   { Numero = 6, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 6).Texto });
                    harmoniaConjugal.NumeroOposto.  Add(new NumeroOposto    { Numero = 7, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 7).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 4, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 4).Texto });
                    harmoniaConjugal.NumeroPassivo. Add(new NumeroPassivo   { Numero = 8, Texto = textosDoAmor.FirstOrDefault(a => a.Numero == 8).Texto });
                    break;

                default:
                    break;
            }

            return harmoniaConjugal;
        }
    }
}