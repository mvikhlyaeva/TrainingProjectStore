﻿using AutoMapper;
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

namespace TrainingProject.Application.Commands.Products.PostProductCommand
{
    public class PostProductCommandHandler : IRequestHandler<PostProductCommandQuery, List<ProductDomainModelForGet>>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public PostProductCommandHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDomainModelForGet>> Handle(PostProductCommandQuery request, CancellationToken cancellationToken)
        {
            var cell = await _context.cells.FirstOrDefaultAsync(cell => cell.Id == request.CellId, cancellationToken);
            if (cell == null)
                throw new ProductNoForeignKeyException();
            var stand = await _context.stands.FirstOrDefaultAsync(st => st.Id == cell.StandId, cancellationToken);
            var storeDepartment = await _context.storeDepartments
                .FirstOrDefaultAsync(sd => sd.StoreId == stand.StoreId && sd.DepartmentId == stand.DepartmentId, cancellationToken);

            List<Product> resultProducts = new List<Product>();

            /*int countId;
            var proddb = await _context.products.OrderByDescending(u => u.Id).ToListAsync(cancellationToken);
            if (proddb.Count() < 1) countId = 1;
            else countId = proddb[0].Id + 1;*/

            var productsdb = await _context.products.Where(u => u.CellId == request.CellId).OrderBy(u => u.Id).ToListAsync(cancellationToken);
            foreach (ProductDomainModelForPost Prod in request.Products)
            {
                if (productsdb.FirstOrDefault(u => u.Id == Prod.Id) != null)
                {
                    if (!(storeDepartment.Scheme == SchemeType.ClientBackAddress && cell.Type == CellType.Client))
                    {
                        productsdb.FirstOrDefault(u => u.Id == Prod.Id).Quantity += Prod.Quantity;
                    }
                    productsdb.FirstOrDefault(u => u.Id == Prod.Id).UpdateDate = DateTime.Now;
                    //resultProducts.Add(productsdb.FirstOrDefault(u => u.Id == Prod.Id));
                }
                else
                {
                    var addProduct = _mapper.Map<Product>(Prod);
                    addProduct.CellId = request.CellId;
                    //addProduct.Id = countId;
                    //countId++;
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