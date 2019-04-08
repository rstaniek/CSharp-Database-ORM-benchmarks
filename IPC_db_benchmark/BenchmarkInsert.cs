using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using IPC.Raymond.Benchmark.DAL.EF;
using IPC.Raymond.Benchmark.DAL.helpers;
using IPC.Raymond.Benchmark.DAL.SQL;
using IPC.Raymond.Benchmark.DAL.SQL.interfaces;
using IPC.Raymond.Benchmark.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Raymond.Benchmark
{
    [SimpleJob(runStrategy: RunStrategy.Throughput, launchCount: 1, warmupCount: 5, targetCount: 10)]
    [MinColumn, MaxColumn, SkewnessColumn, MemoryDiagnoser, RankColumn(BenchmarkDotNet.Mathematics.NumeralSystem.Roman)]
    [HtmlExporter, RPlotExporter, CsvExporter, CsvMeasurementsExporter]
    public class BenchmarkInsert
    {
        private readonly IRepository<Invoice, InsertTable> EntityFrameworkRawRepository;
        private readonly IRepository<InvoiceDto, InsertTableDto> DapperRawSqlRepository, RawSqlRepository, RawSqlStoredProcedureRepository;

        private readonly NorthwindEntities _dbContext;
        private readonly string _connStr = "Data Source=RAYMOND-WORKSTA;Initial Catalog=Northwind;Integrated Security=True";

        private static readonly int OBJECT_COUNT = 64;
        private static readonly int textLength = 65536;
        private List<InsertTable> efList;
        private List<InsertTableDto> dtoList1, dtoList2, dtoList3;

        public BenchmarkInsert()
        {
            _dbContext = new NorthwindEntities();

            EntityFrameworkRawRepository = new EntityFrameworkRepository(_dbContext);
            DapperRawSqlRepository = new DapperRepository(_connStr);
            RawSqlRepository = new RawSqlRepository(_connStr);
            RawSqlStoredProcedureRepository = new StoredProcedureRepository(_connStr);

            //IMPORTANT STEP: BEFORE STARTING THE BENCHMARK - MAKE SURE THE TABLES ARE EMPTY FOR CONSISTENT RESULTS!!!
            //new DatabaseCleanup(_connStr).ClearInsertTables();

            efList = new List<InsertTable>();
            dtoList1 = new List<InsertTableDto>();
            dtoList2 = new List<InsertTableDto>();
            dtoList3 = new List<InsertTableDto>();

            for (int i = 0; i < OBJECT_COUNT; i++)
            {
                efList.Add(InsertTableGenerator.NewEF(textLength));
                dtoList1.Add(InsertTableGenerator.NewDTO(textLength));
                dtoList2.Add(InsertTableGenerator.NewDTO(textLength));
                dtoList3.Add(InsertTableGenerator.NewDTO(textLength));
            }
        }

        [Benchmark]
        public int Insert_EF() => EntityFrameworkRawRepository.InsertRows(efList);

        [Benchmark]
        public int Insert_Dapper() => DapperRawSqlRepository.InsertRows(dtoList1);

        [Benchmark]
        public int Insert_SP() => RawSqlStoredProcedureRepository.InsertRows(dtoList1);

        [Benchmark]
        public int Insert_ADO_NET() => RawSqlRepository.InsertRows(dtoList1);
    }
}
