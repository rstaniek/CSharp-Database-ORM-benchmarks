using IPC.Raymond.Benchmark.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Raymond.Benchmark.DAL.SQL.interfaces
{
    public interface IRepository<TGetAll, TInsert> where TGetAll : new()
    {
        IEnumerable<TGetAll> GetAll();

        int InsertRows(IEnumerable<TInsert> rows);
    }
}
