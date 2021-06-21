using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Application.Commands.Products.DeleteProductCommand;
using TrainingProject.Application.Commands.Products.PostProductCommand;
using TrainingProject.Application.Commands.Products.PutProductCommand;
using TrainingProject.tables;
using TrainProject.Domain.DomainModels.ProductDomainModel;

namespace TrainingProject.Controllers
{
    [Route("api")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("products")]
        [ProducesResponseType(typeof(List<ProductDomainModelForGet>), StatusCodes.Status200OK)]
        public async Task<List<ProductDomainModelForGet>> AddProducts(int cellId, List<ProductDomainModelForPost> products, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new AddProductCommandQuery(cellId, products), cancellationToken);
        }

        [HttpPut("products/{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async Task<ProductDomainModelForGet> ChangeQuantityOfProducts(int id, decimal quantity, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ChangeQuantityProductCommandQuery(id, quantity), cancellationToken);
        }

        [HttpDelete("products/{id}")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        public async Task<Product> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new DeleteProductCommandQuery(id), cancellationToken);
        }
    }
}