using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingProject.tables;
using TrainProject.Domain.DomainModels.ProductDomainModel;

namespace TrainingProject.Application.Commands.Products.PostProductCommand
{
    public class PostProductCommandQuery : IRequest<List<ProductDomainModelForGet>>
    {
        public int CellId { get; }
        public List<ProductDomainModelForPost> Products { get; }

        public PostProductCommandQuery(int cellId, List<ProductDomainModelForPost> products)
        {
            CellId = cellId;
            Products = products;
        }
    }
}