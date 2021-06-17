using LibMotors.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMotors.Application.Features.InventoryItemFeatures.Commands
{
    public class DeleteInventoryItemByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteInventoryItemByIdCommandHandler : IRequestHandler<DeleteInventoryItemByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteInventoryItemByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteInventoryItemByIdCommand command, CancellationToken cancellationToken)
            {
                var inventoryItem = await _context.InventoryItems.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (inventoryItem == null) return default;
                _context.InventoryItems.Remove(inventoryItem);
                await _context.SaveChangesAsync();
                return inventoryItem.Id;
            }
        }
    }
}
