using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Core.Enums;
using TrainingProject.Core.Exceptions.ProductExceptions;
using TrainingProject.tables;
using TrainProject.Domain.DomainModels.ProductDomainModel;

namespace TrainingProject.Application.Commands.Products.PostProductCommand
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandQuery, List<ProductDomainModelForGet>>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public AddProductCommandHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDomainModelForGet>> Handle(AddProductCommandQuery request, CancellationToken cancellationToken)
        {
            var cell = await _context.cells.FirstOrDefaultAsync(cell => cell.Id == request.CellId, cancellationToken);
            if (cell == null)
                throw new ProductNoForeignKeyException();
            var stand = await _context.stands.FirstOrDefaultAsync(st => st.Id == cell.StandId, cancellationToken);
            var storeDepartment = await _context.storeDepartments
                .FirstOrDefaultAsync(sd => sd.StoreId == stand.StoreId && sd.DepartmentId == stand.DepartmentId, cancellationToken);

            List<Product> resultProducts = new List<Product>();

            int countId;
            var proddb = await _context.products.OrderByDescending(u => u.Id).ToListAsync(cancellationToken);
            if (proddb.Count() < 1) countId = 1;
            else countId = proddb[0].Id + 1;

            var productsdb = proddb.Where(u => u.CellId == request.CellId);

            foreach (ProductDomainModelForPost Prod in request.Products)
            {
                var productdb = productsdb.FirstOrDefault(u => u.ProductCode == Prod.ProductCode);
                if (productdb != null)
                {
                    if (!(storeDepartment.Scheme == SchemeType.ClientBackAddress && cell.Type == CellType.Client))
                    {
                        productdb.Quantity += Prod.Quantity;
                    }
                    productdb.UpdateDate = DateTime.Now;
                }
                else
                {
                    var addProduct = _mapper.Map<Product>(Prod);
                    addProduct.CellId = request.CellId;
                    addProduct.Id = countId;
                    countId++;
                    addProduct.UpdateDate = DateTime.Now;
                    if (storeDepartment.Scheme == SchemeType.ClientBackAddress && cell.Type == CellType.Client)
                    {
                        addProduct.Quantity = null;
                    }
                    _context.products.Add(addProduct);
                    resultProducts.Add(addProduct);
                }
            }
            resultProducts.AddRange(productsdb);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<List<ProductDomainModelForGet>>(resultProducts.OrderBy(Pr => Pr.Id).ToList());
        }
    }
}