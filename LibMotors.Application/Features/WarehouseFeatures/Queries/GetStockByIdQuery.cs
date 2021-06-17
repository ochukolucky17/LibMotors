using LibMotors.Application.Interfaces;
using LibMotors.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMotors.Application.Features.WarehouseFeatures.Queries
{
    public class GetStockByIdQuery : IRequest<Warehouse>
    {
        public int Id { get; set; }
        public class GetStockByIdQueryHandler : IRequestHandler<GetStockByIdQuery, Warehouse>
        {
            private readonly IApplicationDbContext _context;
            public GetStockByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Warehouse> Handle(GetStockByIdQuery query, CancellationToken cancellationToken)
            {
                var stock = _context.Warehouses.Where(a => a.Id == query.Id).FirstOrDefault();
                if (stock == null) return null;
                return stock;
            }
        }
    }
}
