using LibMotors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibMotors.Application.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<InventoryItems> InventoryItems  { get; set; }
        DbSet<Warehouse> Warehouses { get; set; }
        DbSet<Employees> Employees { get; set; }
        Task<int> SaveChangesAsync();
    }
}
