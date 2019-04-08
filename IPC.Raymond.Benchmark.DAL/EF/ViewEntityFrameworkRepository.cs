using IPC.Raymond.Benchmark.DAL.SQL.interfaces;
using IPC.Raymond.Benchmark.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Raymond.Benchmark.DAL.EF
{
    public class ViewEntityFrameworkRepository : IRepository<Invoice, InsertTable>
    {
        private readonly NorthwindEntities context;

        public ViewEntityFrameworkRepository(NorthwindEntities context)
        {
            this.context = context;
        }

        public IEnumerable<Invoice> GetAll()
        {
            return context.Invoices.ToList();
        }

        public int InsertRows(IEnumerable<InsertTable> rows)
        {
            int rowCount = 0;
            rows.ToList().ForEach(row =>
            {
                context.InsertTables.Add(row);
                rowCount += 1;
            });
            return rowCount;
        }
    }
}
