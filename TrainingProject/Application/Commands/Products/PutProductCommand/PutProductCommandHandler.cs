using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Core;
using TrainingProject.Core.Exceptions.ProductExceptions;
using TrainingProject.tables;
using TrainProject.Domain.DomainModels.ProductDomainModel;

namespace TrainingProject.Application.Commands.Products.PutProductCommand
{
    public class PutProductCommandHandler : IRequestHandler<PutProductCommandQuery, ProductDomainModelForGet>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public PutProductCommandHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDomainModelForGet> Handle(PutProductCommandQuery request, CancellationToken cancellationToken)
        {
            var Product = await _context.products.FirstOrDefaultAsync(pr => pr.Id == request.Id, cancellationToken);
            if (Product == null)
                throw new ProductNotFoundException();
            var Cell = await _context.cells.FirstOrDefaultAsync(cell => cell.Id == Product.CellId, cancellationToken);
            var Stand = await _context.stands.FirstOrDefaultAsync(st => st.Id == Cell.StandId, cancellationToken);
            var StoreDepartment = await _context.storeDepartments.FirstOrDefaultAsync(sd => sd.StoreId == Stand.StoreId && sd.DepartmentId == Stand.DepartmentId, cancellationToken);

            if (!(StoreDepartment.Scheme == SchemeType.ClientBackAddress && Cell.Type == CellType.Client)) Product.Quantity = request.Quantity;
            Product.UpdateDate = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ProductDomainModelForGet>(Product);
        }
    }
}