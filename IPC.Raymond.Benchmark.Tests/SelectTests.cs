using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IPC.Raymond.Benchmark.DAL.SQL.interfaces;
using IPC.Raymond.Benchmark.DAL.SQL;
using System.Linq;
using IPC.Raymond.Benchmark.DAL.EF;
using IPC.Raymond.Benchmark.DTOs;

namespace IPC.Raymond.Benchmark.Tests
{
    /// <summary>
    /// Summary description for RawSql_Select_tests
    /// </summary>
    [TestClass]
    public class SelectTests
    {
        #region stuff
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        #endregion
        private static readonly string _connStr = "Data Source=RAYMOND-WORKSTA;Initial Catalog=Northwind;Integrated Security=True";
        private static readonly int EXPECTED_COUNT = 2155;

        [TestMethod]
        public void RawSql()
        {
            //arrange
            IRepository<InvoiceDto, InsertTableDto> repo = new RawSqlRepository(_connStr);

            //act
            var results = repo.GetAll();

            //assert
            Assert.AreEqual(EXPECTED_COUNT, results.Count());
        }

        [TestMethod]
        public void RawSqlStoredProcedure()
        {
            //arrange
            IRepository<InvoiceDto, InsertTableDto> repo = new StoredProcedureRepository(_connStr);

            //act
            var results = repo.GetAll();

            //assert
            Assert.AreEqual(EXPECTED_COUNT, results.Count());
        }

        [TestMethod]
        public void Dapper()
        {
            //arrange
            IRepository<InvoiceDto, InsertTableDto> repo = new DapperRepository(_connStr);

            //act
            var results = repo.GetAll();

            //assert
            Assert.AreEqual(EXPECTED_COUNT, results.Count());
        }
    }
}
