using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductController(ApplicationContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("products")]
        [ProducesResponseType(typeof(List<ProductDomainModelForGet>), StatusCodes.Status200OK)]
        public async Task<List<ProductDomainModelForGet>> AddProducts(int cellId, List<ProductDomainModelForPost> products, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new PostProductCommandQuery(cellId, products), cancellationToken);
        }

        [HttpPut("products/{id}")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        public async Task<ProductDomainModelForGet> ChangeQuantityOfProducts(int id, decimal quantity, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new PutProductCommandQuery(id, quantity), cancellationToken);
        }
    }
}