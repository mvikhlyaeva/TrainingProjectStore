using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingProject.tables;
using System.Threading;
using Microsoft.AspNetCore.Http;
using AutoMapper;


namespace TrainingProject.Controllers
{

    [Route("api")]
    [ApiController]
    public class HealthcheckController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public HealthcheckController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("Ind")]
        public Cell Index()
        {

            {
                Cell c1 = new Cell() { Id = 11, Code = "qw23", Position = 2 };
                _context.cells.Add(c1);
                _context.SaveChanges();

                var c2 = _context.cells.ToList();
                Cell res = c2[1];
                return res;
            }
        }

        /*[HttpPost("StoreDeparments")]
        [ProducesResponseType(typeof(StoreDepartmentDomainModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddStoreDepartments([FromBody] StoreDepartmentDomainModel SD, CancellationToken cancellationToken)
        {
            
            _context.storeDepartments.Add(_mapper.Map<StoreDepartment>(SD));
            await _context.SaveChangesAsync(cancellationToken);
            return Ok(SD);
        }*/

        [HttpGet("TestDb1")]
        public async Task<IActionResult> TestDb1(CancellationToken cancellationToken)
        {
            /*StoreDepartment SD = new StoreDepartment { DepartmentId = 30, StoreId = 15, Scheme = SchemeType.OnlyBack };
            _context.storeDepartments.AddRange(SD);
            Stand Stand1 = new Stand { Id = 218, Size = 2, DepartmentId = 30, StoreId = 15 };
             _context.stands.AddRange(Stand1);*/
            //Cell Cell1 = new Cell { Id = 1008, Code = "q123", StandId = 218};
            //_context.cells.Add(Cell1);
            // await _context.SaveChangesAsync(cancellationToken);
            //var Stand = await _context.stands.Include(stand => stand.StoreDepartment).ToListAsync(cancellationToken);//TnenInclude
            var SD = await _context.storeDepartments.Include(sd => sd.Stands).ToListAsync(cancellationToken);

            return Ok(SD);


        }


        [HttpGet("GetCells")]
        public List<Cell> GetCells()
        {

            //StoreDepartment SD = new StoreDepartment { DepartmentId = 28, StoreId = 37, Scheme = SchemeType.OnlyBack };
            //Stand Stand1 = new Stand { Id = 30, Size = 2, DepartmentId = 28, StoreId = 37 };
            //Cell Cell1 = new Cell { Id = 78, Code = "q123", Stand = Stand1 };
            //db.storeDepartments.AddRange(SD);
            //db.stands.AddRange(Stand1);
            //db.cells.Add(Cell1);
            //db.SaveChanges();
            var Cell2 = _context.cells.ToList();
            return Cell2;

        }

        [HttpGet("GetStands")]
        public List<Stand> GetStands()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseNpgsql("Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=Qwert6789")
                .Options;
            using (ApplicationContext db = new ApplicationContext(options))
            {
                var Stand2 = db.stands.ToList();
                return Stand2;

            }
        }

        [HttpGet("TestDb")]
        public string TestDb()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseNpgsql("Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=Qwert6789")
                .Options;
            using (ApplicationContext db = new ApplicationContext(options))
            {
                //StoreDepartment SD = new StoreDepartment { DepartmentId = 7, StoreId = 8, Scheme = SchemeType.OnlyBack };
                Stand Stand1 = new Stand { Id = 18, Size = 2, DepartmentId = 7, StoreId = 10 };
                //db.storeDepartments.AddRange(SD);
                db.stands.AddRange(Stand1);
                db.SaveChanges();
                var Stand2 = db.stands.ToList();
                int len = Stand2.Count - 1;
                return ($"Id = {Stand2[len].Id}, DepartmentId = {Stand2[len].StoreDepartment.DepartmentId}");
            }
        }


    }
}
