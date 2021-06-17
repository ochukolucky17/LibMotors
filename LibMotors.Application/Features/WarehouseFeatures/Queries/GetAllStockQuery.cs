using LibMotors.Application.Interfaces;
using LibMotors.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMotors.Application.Features.WarehouseFeatures.Queries
{
    public class GetAllStockQuery : IRequest<IEnumerable<Warehouse>>
    {
        public class GetAllStockQueryHandler : IRequestHandler<GetAllStockQuery, IEnumerable<Warehouse>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllStockQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Warehouse>> Handle(GetAllStockQuery query, CancellationToken cancellationToken)
            {
                var warehouseList = await _context.Warehouses.ToListAsync();
                if (warehouseList == null)
                {
                    return null;
                }
                return warehouseList.AsReadOnly();
            }
        }
    }
}
