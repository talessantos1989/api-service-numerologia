using System.ComponentModel.DataAnnotations;

namespace NumerologiaCabalistica.Models.MapaRelatorio
{
    public class ParametroCalculoNumerologia
    {
        [Required(ErrorMessage = "Favor, informar a Data de Nascimento")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Favor, informar a Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataDeNascimento { get; set; }

    }
}
