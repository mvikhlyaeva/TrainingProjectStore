using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Core;
using TrainingProject.Domain;
using TrainingProject.tables;

namespace TrainingProject.Application.Queries.StoreDepartments.GetStoreDepartment
{
    public class GetStoreDepartmentHandler : IRequestHandler<GetStoreDepartmentQuery, StoreDepartmentDomainModel>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public GetStoreDepartmentHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StoreDepartmentDomainModel> Handle(GetStoreDepartmentQuery request, CancellationToken cancellationToken)
        {
            var storeDepartment = await _context.storeDepartments.FirstOrDefaultAsync(sd => sd.StoreId == request.StoreId && sd.DepartmentId == request.DepartmentId, cancellationToken);

            if (storeDepartment == null)
                throw new StoreDepartmentNotFoundException();
            return _mapper.Map<StoreDepartmentDomainModel>(storeDepartment);
        }
    }
}