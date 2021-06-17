using LibMotors.Application.Interfaces;
using LibMotors.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMotors.Application.Features.InventoryItemFeatures.Queries
{
    public class GetAll_InventoryItemsQuery : IRequest<IEnumerable<InventoryItems>>
    {
        public class GetAll_InventoryItemsQueryQueryHandler : IRequestHandler<GetAll_InventoryItemsQuery, IEnumerable<InventoryItems>>
        {
            private readonly IApplicationDbContext _context;
            public GetAll_InventoryItemsQueryQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<InventoryItems>> Handle(GetAll_InventoryItemsQuery query, CancellationToken cancellationToken)
            {
                var InventoryItemList = await _context.InventoryItems.ToListAsync();
                if (InventoryItemList == null)
                {
                    return null;
                }
                return InventoryItemList.AsReadOnly();
            }
        }
    }
}