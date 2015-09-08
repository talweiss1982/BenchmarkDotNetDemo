using BenchmarkDotNet;
using BenchmarkDotNet.Tasks;

namespace BenchmarkDotNetDemo
{
	[BenchmarkTask(platform: BenchmarkPlatform.X86, jitVersion: BenchmarkJitVersion.LegacyJit)]
	[BenchmarkTask(platform: BenchmarkPlatform.X64, jitVersion: BenchmarkJitVersion.LegacyJit)]
	[BenchmarkTask(platform: BenchmarkPlatform.X64, jitVersion: BenchmarkJitVersion.RyuJit)]
	public class Cpu_Ilp_Inc_Demo
	{
		private double a, b, c, d;

		[Benchmark]
		[OperationsPerInvoke(4)]
		public void Parallel()
		{
			a++;
			b++;
			c++;
			d++;
		}

		[Benchmark]
		[OperationsPerInvoke(4)]
		public void Sequential()
		{
			a++;
			a++;
			a++;
			a++;
		}
		public void RunDemo()
		{
			var tests = new BenchmarkCompetitionSwitch(new[] { typeof(Cpu_Ilp_Inc_Demo) });
			tests.Run(new[] { "#0" });
		}
	}
}
