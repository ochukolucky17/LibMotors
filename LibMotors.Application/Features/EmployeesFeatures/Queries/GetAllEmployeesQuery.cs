using LibMotors.Application.Interfaces;
using LibMotors.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMotors.Application.Features.EmployeesFeatures.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<Employees>>
    {
        public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employees>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllEmployeesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Employees>> Handle(GetAllEmployeesQuery query, CancellationToken cancellationToken)
            {
                var employeestList = await _context.Employees.ToListAsync();
                if (employeestList == null)
                {
                    return null;
                }
                return employeestList.AsReadOnly();
            }
        }
    }
}
