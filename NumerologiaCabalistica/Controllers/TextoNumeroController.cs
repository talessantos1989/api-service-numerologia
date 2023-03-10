using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Data.DTO.Categoria;
using NumerologiaCabalistica.Data.DTO.Texto;
using NumerologiaCabalistica.Models.TextosNumericos;

namespace NumerologiaCabalistica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextoNumeroController : ControllerBase
    {
        private readonly NumerologiaCabalisticaDbContext _dbContext;
        private IMapper _mapper;

        public TextoNumeroController(NumerologiaCabalisticaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarTextoNumerico(CreateTextoDTO createTextoDTO)
        {
            TextoNumericoModel texto = _mapper.Map<TextoNumericoModel>(createTextoDTO);
            _dbContext.TextoNumerico.Add(texto);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(RecuperarTextoPorId), new { Id = texto.Id }, texto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarTextoPorId(int id)
        {
            TextoNumericoModel texto = _dbContext.TextoNumerico.FirstOrDefault(a => a.Id == id);
            if (texto != null)
            {
                ReadTextoDTO textoDTO = _mapper.Map<ReadTextoDTO>(texto);
                return Ok(textoDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTexto(int id, [FromBody] UpdateTextoDTO textoDTO)
        {
            TextoNumericoModel texto = _dbContext.TextoNumerico.FirstOrDefault(texto => texto.Id == id);
            if (texto != null)
            {
                _mapper.Map<UpdateTextoDTO>(texto);
                _dbContext.Update(texto);
                _dbContext.SaveChanges();
                return Ok(texto);

            }
            else return NotFound();
        }

        [HttpGet]
        public IEnumerable<TextoNumericoModel> RecuperarTexto()
        {
            return _dbContext.TextoNumerico;
        }
    }
}
