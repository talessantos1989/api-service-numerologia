using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace NumerologiaCabalistica.Models.DiasMesFavoraveis
{
    public class MesModel
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [JsonIgnore]
        public virtual List<DiaDoMesFavoravelModel> DiasDoMesFavoraveis { get; set; }

        public string Mes { get; set; }

        public int MesNumeral { get; set; }
    }
}
