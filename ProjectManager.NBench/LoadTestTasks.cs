using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectManager.API.Controllers;
using ProjectManager.Entities.DataModels;
using NBench;

namespace ProjectManager.NBench
{
    public class LoadTestTasks
    {
        TasksController tasksController = new TasksController();
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
            tasksController.GetTasks();
            _counter.Increment();
        }
        int counter = 1;
        [PerfBenchmark(NumberOfIterations = 100, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("MyCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        public void postPerformanceAsync()
        {

            Tasks testTask = new Tasks
            {
                Id = 0,
                Name = "Testing Task" + counter.ToString(),
                Start_Date = DateTime.Today,
                End_Date = DateTime.Today,
                Priority = 5,
                User = 1,
                status = false,
                Project_Id = 1
            };
            tasksController.PostTasks(testTask);
        }
    }
}
