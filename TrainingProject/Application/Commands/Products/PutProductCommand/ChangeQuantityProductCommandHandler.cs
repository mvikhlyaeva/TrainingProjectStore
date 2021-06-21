using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Core.Enums;
using TrainingProject.Core.Exceptions.ProductExceptions;
using TrainingProject.tables;
using TrainProject.Domain.DomainModels.ProductDomainModel;

namespace TrainingProject.Application.Commands.Products.PutProductCommand
{
    public class ChangeQuantityProductCommandHandler : IRequestHandler<ChangeQuantityProductCommandQuery, ProductDomainModelForGet>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public ChangeQuantityProductCommandHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDomainModelForGet> Handle(ChangeQuantityProductCommandQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.products.FirstOrDefaultAsync(pr => pr.Id == request.Id, cancellationToken);
            if (product == null)
                throw new ProductNotFoundException();
            var cell = await _context.cells.FirstOrDefaultAsync(c => c.Id == product.CellId, cancellationToken);
            var stand = await _context.stands.FirstOrDefaultAsync(st => st.Id == cell.StandId, cancellationToken);
            var storeDepartment = await _context.storeDepartments
                .FirstOrDefaultAsync(sd => sd.StoreId == stand.StoreId && sd.DepartmentId == stand.DepartmentId, cancellationToken);

            if (!(storeDepartment.Scheme == SchemeType.ClientBackAddress && cell.Type == CellType.Client))
            {
                product.Quantity = request.Quantity;
            }
            product.UpdateDate = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ProductDomainModelForGet>(product);
        }
    }
}