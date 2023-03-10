using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace NumerologiaCabalistica.Models.TextosNumericos
{
    public class CategoriaNumeroPessoalModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Categoria { get; set; }

        //public string Descricao{ get; set; }

        [JsonIgnore]
        public virtual List<TextoNumericoModel> TextoNumerico { get; set; }
    }
}
