using LibMotors.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibMotors.Domain.Entities
{
    public enum Gender { male, Female}
    public class Employees : BaseEntity
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Gender? Gender { get; set; }
        public DateTime DOB { get; set; }
        public string JobId { get; set; }
        public string Position { get; set; }
        public DateTime HiredDate { get; set; }
        public string LocationId { get; set; }

        public virtual ICollection<InventoryItems> InventoryItems { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
