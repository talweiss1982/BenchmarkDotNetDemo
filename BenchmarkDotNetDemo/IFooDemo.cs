using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkDotNetDemo
{
	class IFooDemo
	{
		interface IFoo
		{
			int Inc(int x);
		}
		class Foo1 : IFoo
		{
			public int Inc(int x)
			{
				return x + 1;
			}
		}
		class Foo2 : IFoo
		{
			public int Inc(int x)
			{
				return x + 1;
			}
		}
		void Run(IFoo foo)
		{
			for (int i = 0; i < 1000001; i++)
				foo.Inc(0);
		}
		void Run1()
		{
			Run(new Foo1());
		}
		void Run2()
		{
			Run(new Foo2());
		}

		public void RunDemo()
		{
			var sw = new Stopwatch();		
			sw.Start();
			Run1();
			sw.Stop();
			Console.WriteLine("It took {0}ms to run Foo1 implementation.",sw.ElapsedMilliseconds);
			sw.Restart();
			Run2();
			sw.Stop();
			Console.WriteLine("It took {0}ms to run Foo2 implementation.", sw.ElapsedMilliseconds);			
		}
	}
}
