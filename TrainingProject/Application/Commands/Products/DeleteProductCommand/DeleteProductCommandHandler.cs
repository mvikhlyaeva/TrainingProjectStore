using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.tables;

namespace TrainingProject.Application.Commands.Products.DeleteProductCommand
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandQuery, Product>
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Product> Handle(DeleteProductCommandQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.products.FirstOrDefaultAsync(pr => pr.Id == request.Id, cancellationToken);
            _context.products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }
    }
}