using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Data.DTO.Categoria;
using NumerologiaCabalistica.Models.TextosNumericos;
using System.ComponentModel;

namespace NumerologiaCabalistica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaNumerosPessoaisController : ControllerBase
    {

        private NumerologiaCabalisticaDbContext _context { get; set; }

        public IMapper _mapper { get; set; }

        public CategoriaNumerosPessoaisController(NumerologiaCabalisticaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarCategorias([FromBody] CreateCategoriaDTO categoriaDto)
        {
            CategoriaNumeroPessoalModel categoria = _mapper.Map<CategoriaNumeroPessoalModel>(categoriaDto);
            _context.CategoriaNumero.Add(categoria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarCategoriaPorId), new { id = categoria.Id }, categoria);
        }


        [HttpGet]
        public IEnumerable<CategoriaNumeroPessoalModel> RecuperarCategorias()
        {
            return _context.CategoriaNumero;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCategoriaPorId(int id)
        {
            var categoria = _context.CategoriaNumero.FirstOrDefault(x => x.Id == id);
            if (categoria == null) return NotFound();
            var filmeDto = _mapper.Map<ReadCategoriaDTO>(categoria);
            return Ok(filmeDto);
        }

        //http put precisa passar o objeto inteiro
        [HttpPut("{id}")]
        public IActionResult UpdateCategoria(int id, [FromBody] UpdateCategoriaDTO categoriaDTO)
        {
            var categoria = _context.CategoriaNumero.FirstOrDefault(cat => cat.Id == id);
            if (categoria == null) return NotFound();
            _mapper.Map(categoriaDTO, categoria);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpPatch("{id}")]
        public IActionResult UpdateCategoriaParcial(int id, JsonPatchDocument<UpdateCategoriaDTO> patch)
        {
            var categoria = _context.CategoriaNumero.FirstOrDefault(
                cat => cat.Id == id);
            if (categoria == null) return NotFound();

            var categoriaParaAtualizar = _mapper.Map<UpdateCategoriaDTO> (categoria);

            patch.ApplyTo(categoriaParaAtualizar, ModelState);
            if (!TryValidateModel(categoriaParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(categoriaParaAtualizar, categoria);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoria(int id)
        {
            var categoriaExcluir = _context.CategoriaNumero.FirstOrDefault(
                cat => cat.Id == id);
            if (categoriaExcluir == null) return NotFound();

            _context.Remove(categoriaExcluir);
            _context.SaveChanges();
            return NoContent(); 

        }
    }
}
