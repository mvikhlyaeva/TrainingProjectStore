﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Core.Exceptions.StandExceptions;
using TrainingProject.Core.Exceptions.StandExceptons;
using TrainingProject.tables;
using TrainProject.Domain.DomainModels;

namespace TrainingProject.Application.Queries.Stands.PostStand
{
    public class UpdateStandCommandHandler : IRequestHandler<UpdateStandCommandQuery, List<StandDomainModelForPost>>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public UpdateStandCommandHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<StandDomainModelForPost>> Handle(UpdateStandCommandQuery request, CancellationToken cancellationToken)
        {
            var storeDepartment = await _context.storeDepartments
                .FirstOrDefaultAsync(sd => sd.StoreId == request.StoreId && sd.DepartmentId == request.DepartmentId, cancellationToken);
            if (storeDepartment == null)
                throw new StandNoForeignKeyException();

            var standsdb = await _context.stands
                .Where(u => u.StoreId == request.StoreId && u.DepartmentId == request.DepartmentId)
                .OrderBy(u => u.Id)
                .ToListAsync(cancellationToken);

            var stands = request.Stands.OrderBy(st => st?.Id).ToList();

            int j = 0, i = 0;
            for (; i < standsdb.Count() && j < stands.Count();)
            {
                if (stands[i].Size <= 0 || stands[i].Size > 3) throw new StandIncorrectSizeException();
                if (stands[i].Side <= 0) throw new StandIncorrectSideException();
                if (stands[j].Id == null) { j++; continue; }
                if (standsdb[i].Id == stands[j].Id)
                {
                    standsdb[i].Position = stands[j].Position;
                    standsdb[i].Size = stands[j].Size;
                    standsdb[i].Code = stands[j].Code;
                    standsdb[i].Side = stands[j].Side;
                    i++; j++;
                }
                else if (standsdb[i].Id < stands[j].Id)
                {
                    _context.stands.Remove(standsdb[i]);
                    standsdb.Remove(standsdb[i]);
                    i++;
                }
                else { j++; }
            }

            while (i < standsdb.Count())
            {
                _context.stands.Remove(standsdb[i]);
                standsdb.Remove(standsdb[i]);
                i++;
            }

            await _context.SaveChangesAsync(cancellationToken);
            j = 0;
            var standsdbAll = await _context.stands.OrderBy(u => u.Id).ToListAsync(cancellationToken);
            while (j < stands.Count() && stands[j].Id == null)
            {
                Stand stand = new Stand();

                if (standsdbAll.Any())
                {
                    stands[j].Id = standsdbAll[standsdbAll.Count() - 1].Id + j + 1;
                }
                else stands[j].Id = j + 1;
                stand = _mapper.Map<Stand>(stands[j]);

                stand.StoreId = request.StoreId;
                stand.DepartmentId = request.DepartmentId;
                _context.stands.Add(stand);
                standsdb.Add(stand);
                j++;
            }
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<List<StandDomainModelForPost>>(standsdb);
        }
    }
}