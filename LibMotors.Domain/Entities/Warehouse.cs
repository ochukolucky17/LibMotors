using LibMotors.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibMotors.Domain.Entities
{
    public class Warehouse : BaseEntity
    {

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

        public virtual Employees Employees { get; set; }
        public virtual ICollection<InventoryItems> InventoryItems { get; set; }

    }
}
