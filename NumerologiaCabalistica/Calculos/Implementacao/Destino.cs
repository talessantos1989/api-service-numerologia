using Microsoft.Extensions.Primitives;
using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Util;
using System.Reflection.Metadata;

namespace NumerologiaCabalistica.Calculos.Implementacao
{
    public class Destino
    {
        private readonly ParametroCalculoNumerologia _model;
        private NumerologiaCabalisticaDbContext _context;
        public Destino(ParametroCalculoNumerologia parametrosCalculoNumerologia, NumerologiaCabalisticaDbContext context)
        {
            _model = parametrosCalculoNumerologia;
            _context = context;
        }

        public DestinoModel CalcularDestino()
        {
            DestinoModel destinoModel = new DestinoModel(); 
            int somaDestino = MetodosDeExtensao.SomarDataCompleta(_model.DataDeNascimento);

            if (somaDestino != 11 & somaDestino != 22)
            {
                destinoModel.Numero = MetodosDeExtensao.ReduzirAUmAlgarismo(somaDestino);
            }
            else
                destinoModel.Numero = somaDestino;
        

            destinoModel.Texto = _context.TextoNumerico.FirstOrDefault(texto => texto.Numero == destinoModel.Numero && texto.CategoriaId == destinoModel.NumeroCategoria).Texto;



            return destinoModel;
        }
    }
}
