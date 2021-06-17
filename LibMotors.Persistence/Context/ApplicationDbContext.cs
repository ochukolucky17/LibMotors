using LibMotors.Application.Interfaces;
using LibMotors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibMotors.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<InventoryItems> InventoryItems { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>().HasData(new Employees
            {
                Id = 1,
                Fullname = "Uncle Bob",
                Email = "uncle.bob@gmail.com",
                Mobile = "999-888-7777",
                Gender = Gender.male,
                DOB = DateTime.Parse("2001-09-01"),
                JobId = "B9A09",
                Position = "WarehouseManager",
                HiredDate = DateTime.Parse("2001-09-01"),
                LocationId = "S034b9"


            }, new Employees
            {
                Id = 2,
                Fullname = "ochuko Lucky",
                Email = "uncle.ochuko@gmail.com",
                Mobile = "888-888-7777",
                Gender = Gender.male,
                DOB = DateTime.Parse("2001-09-01"),
                JobId = "CC9A09",
                Position = "WarehouPersonel",
                HiredDate = DateTime.Parse("2001-09-01"),
                LocationId = "C034b9"
            }); ; ;

            modelBuilder.Entity<InventoryItems>().HasData(new InventoryItems
            {
                Id = 1,
                StockItem = "Iphone",
                StockOwner= " marrt Bob" ,
                OwnerContact = "999-888-7777",
                ItemStatus = "Shift",
                ShipmentCost = 8000,
                ShipmentDate = DateTime.Parse("2001-09-01"),
                DeliveryDate = DateTime.Parse("2001-09-01"),
                ReceiptName = "john dev",
                ReceiptDetails = "Hello word"

            }, new InventoryItems
            {
                Id = 2,
                StockItem = "Iphone",
                StockOwner = " marrt Bob",
                OwnerContact = "999-888-7777",
                ItemStatus = "Shift",
                ShipmentCost = 8000,
                ShipmentDate = DateTime.Parse("2001-09-01"),
                DeliveryDate = DateTime.Parse("2001-09-01"),
                ReceiptName = "john dev",
                ReceiptDetails = "Hello word"
            });; 
        }


    }
}
