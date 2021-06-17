using LibMotors.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMotors.Application.Features.WarehouseFeatures.Commands
{
    public class DeleteStockByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteInventoryItemByIdCommandHandler : IRequestHandler<DeleteStockByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteInventoryItemByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteStockByIdCommand command, CancellationToken cancellationToken)
            {
                var stockItem = await _context.Warehouses.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (stockItem == null) return default;
                _context.Warehouses.Remove(stockItem);
                await _context.SaveChangesAsync();
                return stockItem.Id;
            }
        }
    }
}
