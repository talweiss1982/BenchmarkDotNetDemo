using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BenchmarkDotNetDemo
{
	class InliningDemo
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]		
		bool True1()
		{
			return true;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		bool True2()
		{
			return true;
		}

		internal void RunDemo()
		{
			var sw = new Stopwatch();
			sw.Start();
			for (int i = 0; i < 10*1000*1000; i++)
				if (!True1())
				{
					Console.WriteLine("This should never be invoked!");
				}
			sw.Stop();
			Console.WriteLine("It took {0}ms to run True1 with aggressiveInlining",sw.ElapsedMilliseconds);
			sw.Restart();
			for (int i = 0; i < 10*1000*1000; i++)
				if (!True2())
				{
					Console.WriteLine("This should never be invoked!");
				}
			sw.Stop();
			Console.WriteLine("It took {0}ms to run True2 without Inlining", sw.ElapsedMilliseconds);
		}
	}
}
