using LibMotors.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMotors.Application.Features.WarehouseFeatures.Commands
{
    public class UpdateStockCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string StockName { get; set; }
        public string RefNumber { get; set; }
        public int StockIn { get; set; }
        public int StockOut { get; set; }
        public int FinalStock { get; set; }
        public string StockReport { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime MoveMovementDate { get; set; }
        public string WarehouseAdress { get; set; }
        public string WarehouseLocation { get; set; }

        public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateStockCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateStockCommand command, CancellationToken cancellationToken)
            {
                var Stock = _context.Warehouses.Where(a => a.Id == command.Id).FirstOrDefault();
                if (Stock == null)
                {
                    return default;
                }
                else
                {
                    Stock.StockName = command.StockName;
                    Stock.RefNumber = command.RefNumber;
                    Stock.StockIn = command.StockIn;
                    Stock.StockOut = command.StockOut;
                    Stock.StockReport = command.StockReport;
                    Stock.CreatedDate = command.CreatedDate;
                    Stock.MoveMovementDate = command.MoveMovementDate;
                    Stock.WarehouseAdress = command.WarehouseAdress;
                    Stock.WarehouseLocation = command.WarehouseLocation;

                    _context.Warehouses.Add(Stock);
                    await _context.SaveChangesAsync();
                    return Stock.Id;
                }
            }
        }
    }
}
