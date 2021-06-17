using LibMotors.Application.Interfaces;
using LibMotors.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMotors.Application.Features.EmployeesFeatures.Commands
{
    public class UpdateEmployeesCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Gender? Gender { get; set; }
        public DateTime DOB { get; set; }
        public string JobId { get; set; }
        public string Position { get; set; }
        public DateTime HiredDate { get; set; }
        public string LocationId { get; set; }

        public class UpdateStockCommandHandler : IRequestHandler<UpdateEmployeesCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateStockCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateEmployeesCommand command, CancellationToken cancellationToken)
            {
                var employees = _context.Employees.Where(a => a.Id == command.Id).FirstOrDefault();
                if (employees == null)
                {
                    return default;
                }
                else
                {
                    employees.Fullname = command.Fullname;
                    employees.Email = command.Email;
                    employees.Mobile = command.Mobile;
                    employees.Gender = command.Gender;
                    employees.DOB = command.DOB;
                    employees.JobId = command.JobId;
                    employees.Position = command.Position;
                    employees.HiredDate = command.HiredDate;
                    employees.LocationId = command.LocationId;

                    _context.Employees.Add(employees);
                    await _context.SaveChangesAsync();
                    return employees.Id;
                }
            }

        }
    }
}
