using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IPC.Raymond.Benchmark.DAL.helpers;
using IPC.Raymond.Benchmark.DAL.SQL;
using IPC.Raymond.Benchmark.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IPC.Raymond.Benchmark.Tests
{
    [TestClass]
    public class InsertTest
    {
        private static readonly string _connStr = "Data Source=RAYMOND-WORKSTA;Initial Catalog=Northwind;Integrated Security=True";
        private static readonly int strSize = 1024;

        private readonly IEnumerable<InsertTableDto> dtos;
        private readonly InsertTableDto single;

        public InsertTest()
        {
            single = new InsertTableDto { id = Guid.NewGuid(), textVar = StringGeneratorHelper.RandomString(strSize, false), number1 = 42, timestamp = DateTime.Now };
            var list = new List<InsertTableDto>()
            {
                single,
                new InsertTableDto {id = Guid.NewGuid(), textVar = StringGeneratorHelper.RandomString(strSize, false), number1 = 42, timestamp = DateTime.Now },
                new InsertTableDto {id = Guid.NewGuid(), textVar = StringGeneratorHelper.RandomString(strSize, false), number1 = 42, timestamp = DateTime.Now },
                new InsertTableDto {id = Guid.NewGuid(), textVar = StringGeneratorHelper.RandomString(strSize, false), number1 = 42, timestamp = DateTime.Now },
                new InsertTableDto {id = Guid.NewGuid(), textVar = StringGeneratorHelper.RandomString(strSize, false), number1 = 42, timestamp = DateTime.Now },
                new InsertTableDto {id = Guid.NewGuid(), textVar = StringGeneratorHelper.RandomString(strSize, false), number1 = 42, timestamp = DateTime.Now },
                new InsertTableDto {id = Guid.NewGuid(), textVar = StringGeneratorHelper.RandomString(strSize, false), number1 = 42, timestamp = DateTime.Now },
                new InsertTableDto {id = Guid.NewGuid(), textVar = StringGeneratorHelper.RandomString(strSize, false), number1 = 42, timestamp = DateTime.Now },
                new InsertTableDto {id = Guid.NewGuid(), textVar = StringGeneratorHelper.RandomString(strSize, false), number1 = 42, timestamp = DateTime.Now },
                new InsertTableDto {id = Guid.NewGuid(), textVar = StringGeneratorHelper.RandomString(strSize, false), number1 = 42, timestamp = DateTime.Now }
            };
            dtos = list;
        }

        [TestMethod]
        public void RawSql_Single()
        {
            //arrange
            var repo = new RawSqlRepository(_connStr);

            //act
            int rows = repo.InsertRows(new List<InsertTableDto> { single });

            //assert
            Assert.AreEqual(1, rows);
        }

        [TestMethod]
        public void RawSql_Multiple()
        {
            //arrange
            var repo = new RawSqlRepository(_connStr);

            //act
            int rows = repo.InsertRows(dtos);

            //assert
            Assert.AreEqual(dtos.Count(), rows);
        }

        [TestMethod]
        public void StoredProcedure_Single()
        {
            //arrange
            var repo = new StoredProcedureRepository(_connStr);

            //act
            int rows = repo.InsertRows(new List<InsertTableDto> { single });

            //assert
            Assert.AreEqual(1, rows);
        }

        [TestMethod]
        public void StoredProcedure_Multiple()
        {
            //arrange
            var repo = new StoredProcedureRepository(_connStr);

            //act
            int rows = repo.InsertRows(dtos);

            //assert
            Assert.AreEqual(dtos.Count(), rows);
        }

        [TestMethod]
        public void Dapper_Single()
        {
            //arrange
            var repo = new DapperRepository(_connStr);

            //act
            int rows = repo.InsertRows(new List<InsertTableDto> { single });

            //assert
            Assert.AreEqual(1, rows);
        }

        [TestMethod]
        public void Dapper_Multiple()
        {
            //arrange
            var repo = new DapperRepository(_connStr);

            //act
            int rows = repo.InsertRows(dtos);

            //assert
            Assert.AreEqual(dtos.Count(), rows);
        }
    }
}
