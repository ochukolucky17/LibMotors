using LibMotors.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibMotors.Domain.Entities
{
    public class InventoryItem : BaseEntity
    {
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

        // referencing Warehouse table and Employees
        public virtual Warehouse Warehouse { get; set; }
        public virtual Employees Employees { get; set; }

    }
}
