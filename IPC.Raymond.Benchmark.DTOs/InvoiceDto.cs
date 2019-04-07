using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Raymond.Benchmark.DTOs
{
    public class InvoiceDto
    {
        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipRegion { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipCountry { get; set; }

        public string CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Salesperson { get; set; }

        public int OrderID { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public string ShipperName { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public float Discount { get; set; }

        public decimal? ExtendedPrice { get; set; }

        public decimal? Freight { get; set; }

        #region overrides
        public override string ToString()
        {
            return $"ProductID: {ProductID}, ExtendedPrice: {ExtendedPrice}, Quantity: {Quantity}, Order Date: {OrderDate}\n";
        }
        #endregion
    }
}
