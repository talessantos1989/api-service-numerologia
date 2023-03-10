using System.ComponentModel.DataAnnotations;

namespace NumerologiaCabalistica.Data.DTO.Categoria
{
    public class CreateCategoriaDTO
    {

        [Required]
        public string Categoria { get; set; }

        //public string Descricao { get; set; }
    }
}
