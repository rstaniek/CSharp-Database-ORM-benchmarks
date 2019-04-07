using IPC.Raymond.Benchmark.DAL.SQL.interfaces;
using IPC.Raymond.Benchmark.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Raymond.Benchmark.DAL.EF
{
    public class OrderInvoiceViewEntityFrameworkRepository : IRepository<Invoice>
    {
        private readonly NorthwindEntities context;

        public OrderInvoiceViewEntityFrameworkRepository(NorthwindEntities context)
        {
            this.context = context;
        }

        public IEnumerable<Invoice> GetAll()
        {
            return context.Invoices.ToList();
        }
    }
}
