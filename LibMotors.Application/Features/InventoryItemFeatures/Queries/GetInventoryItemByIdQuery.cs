using LibMotors.Application.Interfaces;
using LibMotors.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMotors.Application.Features.InventoryItemFeatures.Queries
{
    public class GetInventoryItemByIdQuery : IRequest<InventoryItems>
    {
        public int Id { get; set; }
        public class GetInventoryItemByIdQueryHandler : IRequestHandler<GetInventoryItemByIdQuery, InventoryItems>
        {
            private readonly IApplicationDbContext _context;
            public GetInventoryItemByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<InventoryItems> Handle(GetInventoryItemByIdQuery query, CancellationToken cancellationToken)
            {
                var InventoryItem = _context.InventoryItems.Where(a => a.Id == query.Id).FirstOrDefault();
                if (InventoryItem == null) return null;
                return InventoryItem;
            }
        }
    }
}