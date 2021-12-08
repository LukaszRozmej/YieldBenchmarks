// See https://aka.ms/new-console-template for more information

using System.Reflection;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run(typeof(YieldBenchmark.YieldBenchmark).Assembly);