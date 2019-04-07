using IPC.Raymond.Benchmark.DAL.SQL.interfaces;
using IPC.Raymond.Benchmark.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Raymond.Benchmark.DAL.SQL
{
    public class OrderInvoiceRawSqlRepository : IRepository<InvoiceDto>
    {
        private readonly string _connStr;

        public OrderInvoiceRawSqlRepository(string connStr)
        {
            _connStr = connStr;
        }

        public IEnumerable<InvoiceDto> GetAll()
        {
            string qry = @"SELECT        dbo.Orders.ShipName, dbo.Orders.ShipAddress, dbo.Orders.ShipCity, dbo.Orders.ShipRegion, dbo.Orders.ShipPostalCode, dbo.Orders.ShipCountry, dbo.Orders.CustomerID, dbo.Customers.CompanyName AS CustomerName, 
                                         dbo.Customers.Address, dbo.Customers.City, dbo.Customers.Region, dbo.Customers.PostalCode, dbo.Customers.Country, dbo.Employees.FirstName + ' ' + dbo.Employees.LastName AS Salesperson, dbo.Orders.OrderID, 
                                         dbo.Orders.OrderDate, dbo.Orders.RequiredDate, dbo.Orders.ShippedDate, dbo.Shippers.CompanyName AS ShipperName, dbo.[Order Details].ProductID, dbo.Products.ProductName, dbo.[Order Details].UnitPrice, 
                                         dbo.[Order Details].Quantity, dbo.[Order Details].Discount, CONVERT(money, (dbo.[Order Details].UnitPrice * dbo.[Order Details].Quantity) * (1 - dbo.[Order Details].Discount) / 100) * 100 AS ExtendedPrice, 
                                         dbo.Orders.Freight
                            FROM            dbo.Shippers INNER JOIN
                                                        dbo.Products INNER JOIN
                                                        dbo.Employees INNER JOIN
                                                        dbo.Customers INNER JOIN
                                                        dbo.Orders ON dbo.Customers.CustomerID = dbo.Orders.CustomerID ON dbo.Employees.EmployeeID = dbo.Orders.EmployeeID INNER JOIN
                                                        dbo.[Order Details] ON dbo.Orders.OrderID = dbo.[Order Details].OrderID ON dbo.Products.ProductID = dbo.[Order Details].ProductID ON dbo.Shippers.ShipperID = dbo.Orders.ShipVia;";
            List<InvoiceDto> invoices = new List<InvoiceDto>();
            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand(qry, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        InvoiceDto dto = new InvoiceDto();
                        dto.ShipName = reader.GetString(0);
                        dto.ShipAddress = reader.GetString(1);
                        dto.ShipCity = reader.GetString(2);
                        try { dto.ShipRegion = reader.GetString(3); }
                        catch (SqlNullValueException) { dto.ShipRegion = null; }
                        try { dto.ShipPostalCode = reader.GetString(4); }
                        catch (SqlNullValueException) { dto.ShipPostalCode = null; }
                        dto.ShipCountry = reader.GetString(5);
                        dto.CustomerID = reader.GetString(6);
                        dto.CustomerName = reader.GetString(7);
                        dto.Address = reader.GetString(8);
                        dto.City = reader.GetString(9);
                        try { dto.Region = reader.GetString(10); }
                        catch (SqlNullValueException) { dto.Region = null; }
                        try { dto.PostalCode = reader.GetString(11); }
                        catch(SqlNullValueException) { dto.PostalCode = null; }
                        dto.Country = reader.GetString(12);
                        dto.Salesperson = reader.GetString(13);
                        dto.OrderID = reader.GetInt32(14);
                        dto.OrderDate = reader.GetDateTime(15);
                        dto.RequiredDate = reader.GetDateTime(16);
                        try { dto.ShippedDate = reader.GetDateTime(17); }
                        catch (SqlNullValueException) { dto.ShippedDate = null; }
                        dto.ShipperName = reader.GetString(18);
                        dto.ProductID = reader.GetInt32(19);
                        dto.ProductName = reader.GetString(20);
                        dto.UnitPrice = reader.GetDecimal(21);
                        dto.Quantity = reader.GetInt16(22);
                        dto.Discount = reader.GetFloat(23);
                        dto.ExtendedPrice = reader.GetDecimal(24);
                        dto.Freight = reader.GetDecimal(25);

                        invoices.Add(dto);
                    }
                }
            }
            return invoices;
        }
    }
}
