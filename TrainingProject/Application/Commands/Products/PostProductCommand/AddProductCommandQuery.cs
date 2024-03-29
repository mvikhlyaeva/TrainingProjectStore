﻿using MediatR;
using System.Collections.Generic;
using TrainProject.Domain.DomainModels.ProductDomainModel;

namespace TrainingProject.Application.Commands.Products.PostProductCommand
{
    public class AddProductCommandQuery : IRequest<List<ProductDomainModelForGet>>
    {
        public int CellId { get; }
        public List<ProductDomainModelForPost> Products { get; }

        public AddProductCommandQuery(int cellId, List<ProductDomainModelForPost> products)
        {
            CellId = cellId;
            Products = products;
        }
    }
}