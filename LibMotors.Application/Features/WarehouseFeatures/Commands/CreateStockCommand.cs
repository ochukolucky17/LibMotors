using LibMotors.Application.Interfaces;
using LibMotors.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMotors.Application.Features.WarehouseFeatures.Commands
{
    public class CreateStockCommand : IRequest<int>
    {
        public string RefNumber { get; set; }
        public int StockIn { get; set; }
        public int StockOut { get; set; }
        public int FinalStock { get; set; }
        public string StockReport { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime MoveMovementDate { get; set; }
        public string WarhouseAdress { get; set; }
        public string WarhouseLocation { get; set; }

        public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateStockCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateStockCommand command, CancellationToken cancellationToken)
            {
                var stock = new Warehouse();
                stock.StockName = stock.StockName;
                stock.RefNumber = command.RefNumber;
                stock.StockIn = command.StockIn;
                stock.StockOut = command.StockOut;
                stock.StockReport = command.StockReport;
                stock.CreatedDate = command.CreatedDate;
                stock.MoveMovementDate = command.MoveMovementDate;
                stock.WarehouseAdress = command.WarhouseLocation;
                stock.WarehouseLocation = command.WarhouseLocation;

                _context.Warehouses.Add(stock);
                await _context.SaveChangesAsync();
                return stock.Id;
            }
        }
    }

}