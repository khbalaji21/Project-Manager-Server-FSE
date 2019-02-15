using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectManager.API.Controllers;
using ProjectManager.Entities.DataModels;
using NBench;

namespace ProjectManager.NBench
{
    public class LoadTestUsers
    {
        UsersController usersController = new UsersController();
        private Counter _counter;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _counter = context.GetCounter("MyCounter");
        }

        [PerfBenchmark(NumberOfIterations = 100, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("MyCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        public void getPerformance()
        {
            usersController.GetUsers();
            _counter.Increment();
        }
        int counter = 1;
        [PerfBenchmark(NumberOfIterations = 100, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("MyCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        public void postPerformance()
        {

            Users testUser = new Users
            {
                Id = 0,
                First_Name = "Load Test" + counter.ToString(),
                Last_Name = "task" + counter.ToString()
            };
            usersController.PostUsers(testUser);
        }
    }
}
