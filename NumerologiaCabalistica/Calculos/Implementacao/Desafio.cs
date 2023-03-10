using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Models.TextosNumericos;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    internal class Desafio
    {
        private ParametroCalculoNumerologia _parametrosCalculoNumerologia;
        private NumerologiaCabalisticaDbContext _context;
        private MapaModel _model;

        public Desafio(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext context, MapaModel model)
        {
            this._parametrosCalculoNumerologia = parametrosCalculoNumerologia;
            this._context = context;
            this._model = model;
        }

        public DesafioModel CalcularDesafio()
        {
            DesafioModel dm = new DesafioModel();
            dm.PrimeiroDesafio = new PrimeiroDesafio();
            dm.SegundoDesafio = new SegundoDesafio();
            dm.TerceiroDesafio = new TerceiroDesafio();

            int somaDia = MetodosDeExtensao.ReduzirAUmAlgarismo(_parametrosCalculoNumerologia.DataDeNascimento.Day);
            int somaMes = MetodosDeExtensao.ReduzirAUmAlgarismo(_parametrosCalculoNumerologia.DataDeNascimento.Month);
            int somaAno = MetodosDeExtensao.ReduzirAUmAlgarismo(_parametrosCalculoNumerologia.DataDeNascimento.Year);

            List<TextoNumericoModel> texto = _context.TextoNumerico.Where(x => x.CategoriaId == dm.CategoriaId).ToList();

            dm.PrimeiroDesafio.Numero = somaDia > somaMes? somaDia - somaMes : somaMes - somaDia;
            dm.PrimeiroDesafio.Texto = texto.FirstOrDefault(texto => texto.Numero == dm.PrimeiroDesafio.Numero).Texto;
            dm.PrimeiroDesafio.AnoDe = _model.PrimeiroCicloDeVida.AnoDe;
            dm.PrimeiroDesafio.AnoAte = _model.PrimeiroCicloDeVida.AnoAte;
            dm.PrimeiroDesafio.IdadeDe = _model.PrimeiroCicloDeVida.IdadeDe;
            dm.PrimeiroDesafio.IdadeAte = _model.PrimeiroCicloDeVida.IdadeAte;


            dm.SegundoDesafio.Numero = somaDia > somaAno ? somaDia - somaAno: somaAno - somaDia;
            dm.SegundoDesafio.Texto = texto.FirstOrDefault(texto => texto.Numero == dm.SegundoDesafio.Numero).Texto;
            dm.SegundoDesafio.AnoDe = _model.SegundoCicloDeVida.AnoDe;
            dm.SegundoDesafio.AnoAte = _model.SegundoCicloDeVida.AnoAte;
            dm.SegundoDesafio.IdadeDe = _model.SegundoCicloDeVida.IdadeDe;
            dm.SegundoDesafio.IdadeAte = _model.SegundoCicloDeVida.IdadeAte;


            dm.TerceiroDesafio.Numero = dm.PrimeiroDesafio.Numero > dm.SegundoDesafio.Numero ? dm.PrimeiroDesafio.Numero - dm.SegundoDesafio.Numero : dm.SegundoDesafio.Numero - dm.PrimeiroDesafio.Numero;
            dm.TerceiroDesafio.Texto = texto.FirstOrDefault(texto => texto.Numero == dm.TerceiroDesafio.Numero).Texto;
            dm.TerceiroDesafio.AnoDe = _model.TerceiroCicloDeVida.AnoDe;
            dm.TerceiroDesafio.IdadeDe = _model.TerceiroCicloDeVida.IdadeDe;

            return dm;

        }
    }
}