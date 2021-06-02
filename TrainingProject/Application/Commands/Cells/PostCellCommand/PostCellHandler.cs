using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Core;
using TrainingProject.Core.Exceptions.CellException;
using TrainingProject.tables;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Application.Queries.Cells.PostCell
{
    public class PostCellHandler : IRequestHandler<PostCellQuery, List<CellDomainModelForPost>>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<PostCellHandler> _logger;

        public PostCellHandler(ApplicationContext context, IMapper mapper, ILogger<PostCellHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<CellDomainModelForPost>> Handle(PostCellQuery request, CancellationToken cancellationToken)
        {
            //_logger.LogInformation(_context);
            var stand = await _context.stands.FirstOrDefaultAsync(st => st.Id == request.StandId, cancellationToken);
            if (stand == null)
                throw new CellNoForeignKeyException();
            var storeDepartment = await _context.storeDepartments.FirstOrDefaultAsync(sd => sd.StoreId == stand.StoreId && sd.DepartmentId == stand.DepartmentId, cancellationToken);

            var cellsdb = await _context.cells.Where(u => u.StandId == request.StandId).OrderBy(u => u.Id).ToListAsync(cancellationToken);
            foreach (CellDomainModelForPost cell in request.Cells)
            {
                if (cellsdb.FirstOrDefault(u => u.Id == cell.Id) != null)
                    throw new CellRepeatKeyException();
                if (storeDepartment.Scheme == SchemeType.OnlyBack && cell.Type == CellType.Client) continue;
                Cell cellAdd = _mapper.Map<Cell>(cell);
                cellAdd.StandId = request.StandId;
                cellsdb.Add(_mapper.Map<Cell>(cell));
                _context.cells.Add(cellAdd);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<List<CellDomainModelForPost>>(cellsdb);
        }
    }
}