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
    public class MesController : ControllerBase
    {
        private readonly NumerologiaCabalisticaDbContext _dbContext;
        private readonly IMapper _mapper;

        public MesController(NumerologiaCabalisticaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CadastrarMes(CreateMesDTO createMesDTO)
        {
            MesModel mes = _mapper.Map<MesModel>(createMesDTO);
            _dbContext.Mes.Add(mes);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(RecuperarMesPorId), new { Id = mes.Id }, mes);
        }


        [HttpGet("{id}")]
        public IActionResult RecuperarMesPorId(int id)
        {
            MesModel mes = _dbContext.Mes.FirstOrDefault(mes => mes.Id == id);
            if (mes != null)
            {
                ReadMesDTO mesDTO = _mapper.Map<ReadMesDTO>(mes);
                return Ok(mesDTO);
            }
            return NotFound();
        }
    }
}
