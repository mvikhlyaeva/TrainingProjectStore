using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingProject.tables;

namespace TrainingProject.Application.Commands.Products.DeleteProductCommand
{
    public class DeleteProductCommandQuery : IRequest<Product>
    {
        public int Id { get; }

        public DeleteProductCommandQuery(int id)
        {
            Id = id;
        }
    }
}