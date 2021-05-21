using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Domain;
using TrainingProject.tables;

namespace TrainingProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class StandController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public StandController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("Stand")]
        [ProducesResponseType(typeof(StandDomainModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddStand([FromBody] StandDomainModel Stand, CancellationToken cancellationToken)
        {

            _context.stands.Add(_mapper.Map<Stand>(Stand));
            await _context.SaveChangesAsync(cancellationToken);
            return Ok(Stand);
        }

        [HttpPost("stands")]
        [ProducesResponseType(typeof(StandDomainModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStands([FromQuery] int storeId, [FromQuery] int departmentId, CancellationToken cancellationToken)
        {
            var stands = await _context.stands.ToListAsync(cancellationToken);
            var resStands = stands.Where(st => st.StoreId == storeId && st.DepartmentId == departmentId);
            //if (stands != null) return Ok(_mapper.Map<List<StandDomainModel>>(resStands));
            if (stands != null) return Ok(resStands);
            else return NotFound();
        }



        /*[HttpPost("stands?storeId = {storeId}&departmentId={departmentId}")]
        //[ProducesResponseType(typeof(StandDomainModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddUpDelStands(Stand stands, CancellationToken cancellationToken)
        {

            //_context.stands.Add(_mapper.Map<Stand>(Stand));
            //await _context.SaveChangesAsync(cancellationToken);
            await Task.Delay(5);
            return Ok(stands);
        }*/


    }
}
