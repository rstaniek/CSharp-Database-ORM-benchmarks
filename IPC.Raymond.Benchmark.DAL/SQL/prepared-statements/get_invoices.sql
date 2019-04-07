CREATE PROCEDURE get_invoices
AS
SELECT        dbo.Orders.ShipName, dbo.Orders.ShipAddress, dbo.Orders.ShipCity, dbo.Orders.ShipRegion, dbo.Orders.ShipPostalCode, dbo.Orders.ShipCountry, dbo.Orders.CustomerID, dbo.Customers.CompanyName AS CustomerName, 
                         dbo.Customers.Address, dbo.Customers.City, dbo.Customers.Region, dbo.Customers.PostalCode, dbo.Customers.Country, dbo.Employees.FirstName + ' ' + dbo.Employees.LastName AS Salesperson, dbo.Orders.OrderID, 
                         dbo.Orders.OrderDate, dbo.Orders.RequiredDate, dbo.Orders.ShippedDate, dbo.Shippers.CompanyName AS ShipperName, dbo.[Order Details].ProductID, dbo.Products.ProductName, dbo.[Order Details].UnitPrice, 
                         dbo.[Order Details].Quantity, dbo.[Order Details].Discount, CONVERT(money, (dbo.[Order Details].UnitPrice * dbo.[Order Details].Quantity) * (1 - dbo.[Order Details].Discount) / 100) * 100 AS ExtendedPrice, 
                         dbo.Orders.Freight
FROM            dbo.Shippers INNER JOIN
                         dbo.Products INNER JOIN
                         dbo.Employees INNER JOIN
                         dbo.Customers INNER JOIN
                         dbo.Orders ON dbo.Customers.CustomerID = dbo.Orders.CustomerID ON dbo.Employees.EmployeeID = dbo.Orders.EmployeeID INNER JOIN
                         dbo.[Order Details] ON dbo.Orders.OrderID = dbo.[Order Details].OrderID ON dbo.Products.ProductID = dbo.[Order Details].ProductID ON dbo.Shippers.ShipperID = dbo.Orders.ShipVia;
GO