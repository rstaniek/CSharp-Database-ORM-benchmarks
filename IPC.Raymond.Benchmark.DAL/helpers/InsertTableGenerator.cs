using IPC.Raymond.Benchmark.DAL.EF;
using IPC.Raymond.Benchmark.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Raymond.Benchmark.DAL.helpers
{
    public static class InsertTableGenerator
    {
        public static InsertTableDto NewDTO(int textLength)
        {
            var tmp = new InsertTableDto()
            {
                id = Guid.NewGuid(),
                textVar = StringGeneratorHelper.RandomString(textLength, true),
                timestamp = DateTime.Now,
                number1 = new Random().Next()
            };
            return tmp;
        }

        public static InsertTable NewEF(int textLength)
        {
            var tmp = new InsertTable()
            {
                id = Guid.NewGuid().ToString(),
                textVar = StringGeneratorHelper.RandomString(textLength, true),
                timestamp = DateTime.Now,
                number1 = new Random().Next()
            };
            return tmp;
        }
    }
}
