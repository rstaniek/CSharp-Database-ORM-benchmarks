using IPC.Raymond.Benchmark.DAL.SQL.interfaces;
using IPC.Raymond.Benchmark.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Raymond.Benchmark.DAL.EF
{
    public class EntityFrameworkRepository : IRepository<Invoice, InsertTable>
    {
        private readonly NorthwindEntities context;

        public EntityFrameworkRepository(NorthwindEntities context)
        {
            this.context = context;
        }

        public IEnumerable<Invoice> GetAll()
        {
            return (from shippers in context.Shippers
                    join orders in context.Orders on shippers.ShipperID equals orders.ShipVia
                    join employees in context.Employees on orders.EmployeeID equals employees.EmployeeID
                    join customers in context.Customers on orders.CustomerID equals customers.CustomerID
                    join order_details in context.Order_Details on orders.OrderID equals order_details.OrderID
                    join products in context.Products on order_details.ProductID equals products.ProductID
                    select new
                    {
                        ShipName = orders.ShipName,
                        ShipAddress = orders.ShipAddress,
                        ShipCity = orders.ShipCity,
                        ShipRegion = orders.ShipRegion,
                        ShipPostalCode = orders.ShipPostalCode,
                        ShipCountry = orders.ShipCountry,
                        CustomerID = orders.CustomerID,
                        CustomerName = customers.CompanyName,
                        Address = customers.Address,
                        City = customers.City,
                        Region = customers.Region,
                        PostalCode = customers.PostalCode,
                        Country = customers.Country,
                        Salesperson = employees.FirstName + " " + employees.LastName,
                        OrderID = orders.OrderID,
                        OrderDate = orders.OrderDate,
                        RequiredDate = orders.RequiredDate,
                        ShippedDate = orders.ShippedDate,
                        ShipperName = shippers.CompanyName,
                        ProductID = order_details.ProductID,
                        ProductName = products.ProductName,
                        UnitPrice = order_details.UnitPrice,
                        Quantity = order_details.Quantity,
                        Discount = order_details.Discount,
                        Freight = orders.Freight
                    }).ToList()
                    .Select(dto => new Invoice
                    {
                        ShipName = dto.ShipName,
                        ShipAddress = dto.ShipAddress,
                        ShipCity = dto.ShipCity,
                        ShipRegion = dto.ShipRegion,
                        ShipPostalCode = dto.ShipPostalCode,
                        ShipCountry = dto.ShipCountry,
                        CustomerID = dto.CustomerID,
                        CustomerName = dto.CustomerName,
                        Address = dto.Address,
                        City = dto.City,
                        Region = dto.Region,
                        PostalCode = dto.PostalCode,
                        Country = dto.Country,
                        Salesperson = dto.Salesperson,
                        OrderID = dto.OrderID,
                        OrderDate = dto.OrderDate,
                        RequiredDate = dto.RequiredDate,
                        ShippedDate = dto.ShippedDate,
                        ShipperName = dto.ShipperName,
                        ProductID = dto.ProductID,
                        ProductName = dto.ProductName,
                        UnitPrice = dto.UnitPrice,
                        Quantity = dto.Quantity,
                        Discount = dto.Discount,
                        Freight = dto.Freight,
                        ExtendedPrice = ((dto.UnitPrice * dto.Quantity) * (1 - (decimal)dto.Discount) / 100) * 100
                    });
        }

        public int InsertRows(IEnumerable<InsertTable> rows)
        {
            int rowCount = 0;
            rows.ToList().ForEach(row =>
            {
                context.InsertTables.Add(row);
                
                rowCount += 1;
            });
            context.SaveChanges();
            return rowCount;
        }
    }
}
