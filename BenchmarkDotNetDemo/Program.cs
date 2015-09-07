using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
						var stringBuilder = new StringBuilderDemo();
						stringBuilder.RunDemo();
						break;
				}
			}

		}

		private static void PrintUssage()
		{
			Console.WriteLine("Please select a demo");
			Console.WriteLine("1 - IFoo.Inc");
			Console.WriteLine("2 - Inlining");
			Console.WriteLine("3 - StringBuilder");
		}
	}
}
