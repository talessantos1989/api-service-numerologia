using System.ComponentModel.DataAnnotations;

namespace NumerologiaCabalistica.Models.DiasMesFavoraveis
{
    public class DiaDoMesFavoravelModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public virtual MesModel Mes { get; set; }

        public int MesId { get; set; }

        public int Dia { get; set; }

        public  int DiaFavoravel { get; set; }
    }
}
