using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Raymond.Benchmark.DTOs
{
    public class InsertTableDto
    {
        public Guid id { get; set; }
        public string textVar { get; set; }
        public DateTime timestamp { get; set; }
        public int number1 { get; set; }
    }
}
