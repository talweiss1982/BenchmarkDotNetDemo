using System;

namespace BenchmarkDotNetDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			PrintUssage();
			var line = Console.ReadLine();
			int demo;
			if (int.TryParse(line, out demo))
			{
				switch (demo)
				{
					case 1:
						var ifoo = new IFooDemo();
						ifoo.RunDemo();
						break;
					case 2:
						var inlining = new InliningDemo();
						inlining.RunDemo();
						break;
					case 3:
						var loopUnrolling = new LoopUnrollingDemo();
						loopUnrolling.RunDemo();
						break;
					case 4:
						var cpu_Ilp_Inc = new Cpu_Ilp_Inc_Demo();
						cpu_Ilp_Inc.RunDemo();
						break;
				}
			}

		}

		private static void PrintUssage()
		{
			Console.WriteLine("Please select a demo");
			Console.WriteLine("1 - IFoo.Inc");
			Console.WriteLine("2 - Inlining");
			Console.WriteLine("3 - Loop Unrolling");
			Console.WriteLine("4 - Instruction-level parallelism ");
		}
	}
}
