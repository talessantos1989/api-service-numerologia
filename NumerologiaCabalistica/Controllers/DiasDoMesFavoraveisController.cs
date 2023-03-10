using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NumerologiaCabalistica.Data;
using NumerologiaCabalistica.Data.DTO.DiasDoMesFavoraveis;
using NumerologiaCabalistica.Models.DiasMesFavoraveis;

namespace NumerologiaCabalistica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiasDoMesFavoraveisController : ControllerBase
    {
        private readonly NumerologiaCabalisticaDbContext _dbContext;
        private readonly IMapper _mapper;

        public DiasDoMesFavoraveisController(NumerologiaCabalisticaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarDiasDoMesFavoraveis(CreateDiasDoMesFavoraveisDTO createDiasDoMesFavoraveisDTO)
        {
            DiaDoMesFavoravelModel diasDoMesFavoraveisModel = _mapper.Map<DiaDoMesFavoravelModel>(createDiasDoMesFavoraveisDTO);
            _dbContext.DiasDoMesFavoraveis.Add(diasDoMesFavoraveisModel);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(RecuperarDiasDoMesFavoraveisPorId), new { Id = diasDoMesFavoraveisModel.Id }, diasDoMesFavoraveisModel);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarDiasDoMesFavoraveisPorId(int id)
        {
            DiaDoMesFavoravelModel diasDoMesFavoraveisModel = _dbContext.DiasDoMesFavoraveis.FirstOrDefault(dias => dias.Id == id);

            if (diasDoMesFavoraveisModel != null)
            {
                ReadDiasDoMesFavoraveisDTO readDiasDoMesFavoraveisDTO = _mapper.Map<ReadDiasDoMesFavoraveisDTO>(diasDoMesFavoraveisModel);
                return Ok(readDiasDoMesFavoraveisDTO);
            }
            return NotFound();
        }
    }
}
