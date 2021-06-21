using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Core;
using TrainingProject.Core.Exceptions.StoreDepartmentExceptions;
using TrainingProject.tables;

namespace TrainingProject.Application.Queries.StoreDepartments.DeleteStoreDepartment
{
    public class DeleteStoreDepartmentCommandHandler : IRequestHandler<DeleteStoreDepartmentCommandQuery, StoreDepartment>
    {
        private readonly ApplicationContext _context;

        public DeleteStoreDepartmentCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<StoreDepartment> Handle(DeleteStoreDepartmentCommandQuery request, CancellationToken cancellationToken)
        {
            var storeDepartment = await _context.storeDepartments
                .Include(sd => sd.Stands)
                .FirstOrDefaultAsync(sd => sd.StoreId == request.StoreId && sd.DepartmentId == request.DepartmentId, cancellationToken);
            if (storeDepartment == null)
                throw new StoreDepartmentNotFoundException();
            if (storeDepartment.Stands.Any())
                throw new StoreDepartmentDeleteException();

            _context.storeDepartments.Remove(storeDepartment);
            await _context.SaveChangesAsync(cancellationToken);
            return storeDepartment;
        }
    }
}