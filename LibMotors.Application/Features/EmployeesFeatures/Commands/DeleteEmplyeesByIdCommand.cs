using LibMotors.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMotors.Application.Features.EmployeesFeatures.Commands
{
    public class DeleteEmplyeesByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteEmplyeesByIdCommandHandler : IRequestHandler<DeleteEmplyeesByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteEmplyeesByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteEmplyeesByIdCommand command, CancellationToken cancellationToken)
            {
                var employees = await _context.Employees.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (employees == null) return default;
                _context.Employees.Remove(employees);
                await _context.SaveChangesAsync();
                return employees.Id;
            }
        }
    }
}
