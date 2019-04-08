using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Raymond.Benchmark.DAL.helpers
{
    public class DatabaseCleanup
    {
        private readonly string _connStr;

        public DatabaseCleanup(string connStr)
        {
            _connStr = connStr;
        }

        public void ClearInsertTables()
        {
            const string qry = "exec clear_insert_tables";
            using (var conn = new SqlConnection(_connStr))
            using(var cmd = new SqlCommand(qry, conn))
            {
                conn.Open();
                Console.WriteLine("Clearing insert databases...");
                cmd.ExecuteNonQuery();
            }
        }
    }
}
