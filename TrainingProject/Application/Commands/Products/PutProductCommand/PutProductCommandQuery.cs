using MediatR;
using TrainProject.Domain.DomainModels.ProductDomainModel;

namespace TrainingProject.Application.Commands.Products.PutProductCommand
{
    public class PutProductCommandQuery : IRequest<ProductDomainModelForGet>
    {
        public int Id { get; }
        public decimal Quantity { get; }

        public PutProductCommandQuery(int id, decimal quantity)
        {
            Id = id;
            Quantity = quantity;
        }
    }
}