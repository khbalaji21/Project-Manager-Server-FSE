using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjectManager.API.Controllers;
using ProjectManager.Entities.DataModels;
using NBench;

namespace ProjectManager.NBench
{
    public class LoadTestProjects
    {
        ProjectsController projectsController = new ProjectsController();
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
            projectsController.GetProjects();
            _counter.Increment();
        }
        int counter = 1;
        [PerfBenchmark(NumberOfIterations = 100, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("MyCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        public void postPerformance()
        {

            Projects testProject = new Projects
            {
                Id = 0,
                Name = "Testing Project" + counter.ToString(),
                Start_Date = DateTime.Today,
                End_Date = DateTime.Today,
                Priority = 5,
                Manager_Id = 1,
                status = false
            };
            projectsController.PostProjects(testProject);
        }
    }
}
