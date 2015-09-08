using BenchmarkDotNet;
using BenchmarkDotNet.Tasks;

namespace BenchmarkDotNetDemo
{
	[BenchmarkTask(platform: BenchmarkPlatform.X64, jitVersion: BenchmarkJitVersion.LegacyJit)]
	[BenchmarkTask(platform: BenchmarkPlatform.X86, jitVersion: BenchmarkJitVersion.LegacyJit)]
	public class LoopUnrollingDemo
	{
		public int Inc(int x)
		{
			return x + 1;
		}

		[Benchmark]
		public void RunInLoop()
		{
			for (var i = 0; i < 1000; i++)
			{
				Inc(i);
			}
		}

		public void RunDemo()
		{
			var tests = new BenchmarkCompetitionSwitch(new[] { typeof(LoopUnrollingDemo) });
			tests.Run(new[] {"#0" });
		}
/*		AverageTime (ns/op): Median = 292.51049; StdDev = 1.58182; Min = 291.43311; Max
		= 297.91904;
		OperationsPerSecond: Median = 3418681.60298; StdDev = 18280.62247; Min = 3356616
		.66539; Max = 3431319.05417;

		// ***** Competition: Finish  *****

		// BenchmarkDotNet=v0.7.7.0
		// OS=Microsoft Windows NT 6.2.9200.0
		// Processor=Intel(R) Core(TM) i7-2600 CPU @ 3.40GHz, ProcessorCount=8
		// Host CLR=MS.NET 4.0.30319.34014, Arch=32-bit
		Common:  Type=LoopUnrollingDemo  Method=RunInLoop  Mode=Throughput  Jit=LegacyJi
		t  .NET=HostFramework

		 Platform |   AvrTime |   StdDev |       op/s |
		--------- |---------- |--------- |----------- |
			  X64 |  85.72 ns | 0.876 ns | 11665841.4 |
			  X86 | 292.51 ns |  1.58 ns |  3418681.6 |

		// ***** Competition: End ******/

	}
}
