using IPC.Raymond.Benchmark.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Raymond.Benchmark.DAL.SQL.interfaces
{
    public interface IRepository<T> where T : new()
    {
        IEnumerable<T> GetAll();
    }
}
