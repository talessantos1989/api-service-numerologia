using System.ComponentModel.DataAnnotations;

namespace NumerologiaCabalistica.Models.TextosNumericos
{
    public class TextoNumericoModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        public virtual CategoriaNumeroPessoalModel Categoria { get; set; }

        [Required]
        public int CategoriaId { get; set; }

    }
}
