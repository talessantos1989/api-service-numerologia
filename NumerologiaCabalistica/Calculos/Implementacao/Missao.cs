using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    public class Missao
    {

        private readonly ParametroCalculoNumerologia _model;
        private readonly MapaModel _mapa;
        NumerologiaCabalisticaDbContext _context;

       

        public Missao(ParametroCalculoNumerologia model, MapaModel mapa, NumerologiaCabalisticaDbContext _context) 
        {
            this._mapa = mapa;
            this._model = model;
            this._context = _context;
        }

        public MissaoModel CalcularMissao()
        {
            _mapa.Missao = new MissaoModel();
            int somaMissao = _mapa.Destino.Numero + _mapa.Expressao.Numero;
            if (somaMissao != 11 & somaMissao != 22)
            {
                _mapa.Missao.Numero = MetodosDeExtensao.ReduzirAUmAlgarismo(somaMissao);
            }
            else _mapa.Missao.Numero = somaMissao;

            _mapa.Missao.Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.Numero == _mapa.Missao.Numero && texto.CategoriaId == _mapa.Missao.NumeroCategoria).Texto;
            return _mapa.Missao;
        }
    }
}
