using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using IPC.Raymond.Benchmark.DAL.EF;
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
    [SimpleJob(runStrategy: RunStrategy.Throughput, launchCount: 1, warmupCount: 5, targetCount: 200)]
    [MinColumn, MaxColumn, MemoryDiagnoser, RankColumn(BenchmarkDotNet.Mathematics.NumeralSystem.Roman)]
    [HtmlExporter, RPlotExporter, CsvExporter, CsvMeasurementsExporter]
    public class BenchmarkSelect
    {
        private readonly IRepository<Invoice> EntityFrameworkRawRepository, EntityFrameworkViewRepository;
        private readonly IRepository<InvoiceDto> DapperRawSqlRepository, RawSqlRepository, RawSqlStoredProcedureRepository;

        private readonly NorthwindEntities _dbContext;
        private readonly string _connStr = "Data Source=RAYMOND-WORKSTA;Initial Catalog=Northwind;Integrated Security=True";

        public BenchmarkSelect()
        {
            _dbContext = new NorthwindEntities();

            EntityFrameworkRawRepository = new OrderInvoiceEntityFrameworkRepository(_dbContext);
            EntityFrameworkViewRepository = new OrderInvoiceViewEntityFrameworkRepository(_dbContext);
            DapperRawSqlRepository = new OrderInvoiceRawSqlDapperRepository(_connStr);
            RawSqlRepository = new OrderInvoiceRawSqlRepository(_connStr);
            RawSqlStoredProcedureRepository = new OrderInvoiceStoredProcedureRepository(_connStr);
        }

        [Benchmark]
        public List<Invoice> Select_EF_Raw()
        {
            return EntityFrameworkRawRepository.GetAll().ToList();
        }

        [Benchmark]
        public List<Invoice> Select_EF_View()
        {
            return EntityFrameworkViewRepository.GetAll().ToList();
        }

        [Benchmark]
        public List<InvoiceDto> Select_Dapper()
        {
            return DapperRawSqlRepository.GetAll().ToList();
        }

        [Benchmark]
        public List<InvoiceDto> Select_ADO_NET()
        {
            return RawSqlRepository.GetAll().ToList();
        }

        [Benchmark]
        public List<InvoiceDto> Select_SP()
        {
            return RawSqlStoredProcedureRepository.GetAll().ToList();
        }
    }
}
