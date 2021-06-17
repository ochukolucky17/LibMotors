using LibMotors.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMotors.Application.Features.InventoryItemFeatures.Commands
{
    public class UpdateInventoryItemCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string StockItem { get; set; }
        public string StockRef { get; set; }
        public string StockOwner { get; set; }
        public string OwnerContact { get; set; }
        public string ItemStatus { get; set; }
        public double ShipmentCost { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ReceiptName { get; set; }
        public string ReceiptDetails { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateInventoryItemCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateInventoryItemCommand command, CancellationToken cancellationToken)
            {
                var inventoryItem = _context.InventoryItems.Where(a => a.Id == command.Id).FirstOrDefault();
                if (inventoryItem == null)
                {
                    return default;
                }
                else
                {
                    inventoryItem.StockItem = command.StockItem;
                    inventoryItem.StockRef = command.StockRef;
                    inventoryItem.StockOwner = command.StockOwner;
                    inventoryItem.OwnerContact = command.OwnerContact;
                    inventoryItem.ItemStatus = command.ItemStatus;
                    inventoryItem.ShipmentCost = command.ShipmentCost;
                    inventoryItem.ShipmentDate = command.ShipmentDate;
                    inventoryItem.DeliveryDate = command.DeliveryDate;
                    inventoryItem.ReceiptDetails = command.ReceiptDetails;

                    _context.InventoryItems.Add(inventoryItem);
                    await _context.SaveChangesAsync();
                    return inventoryItem.Id;
                }
            }
        }

    }
}
