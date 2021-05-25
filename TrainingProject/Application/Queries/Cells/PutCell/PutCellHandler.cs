﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Core.Exceptions.CellException;
using TrainingProject.tables;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Application.Queries.Cells.PutCell
{
    public class PutCellHandler : IRequestHandler<PutCellQuery, Cell>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public PutCellHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Cell> Handle(PutCellQuery request, CancellationToken cancellationToken)
        {
            Cell celldb = await _context.cells.FirstOrDefaultAsync(cells => cells.Id == request.CellId);
            if (celldb == null)
                throw new CellNotFoundException();
            celldb.Position = request.Cell.Position;
            celldb.Shelf = request.Cell.Shelf;
            celldb.Code = request.Cell.Code;
            celldb.Type = request.Cell.Type;
            _context.SaveChangesAsync(cancellationToken);
            return celldb;

        }
    }
}
