using LibMotors.Application.Interfaces;
using LibMotors.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMotors.Application.Features.EmployeesFeatures.Queries
{
    public class GetEmplyeesByIdQuery : IRequest<Employees>
    {
        public int Id { get; set; }
        public class GetEmplyeesByIdQueryHandler : IRequestHandler<GetEmplyeesByIdQuery, Employees>
        {
            private readonly IApplicationDbContext _context;
            public GetEmplyeesByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Employees> Handle(GetEmplyeesByIdQuery query, CancellationToken cancellationToken)
            {
                var employees= _context.Employees.Where(a => a.Id == query.Id).FirstOrDefault();
                if (employees == null) return null;
                return employees;
            }
        }
    }
}
