using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkDotNetDemo
{
	class StringBuilderDemo
	{
		void StringBuildAppend()
		{
			var sb = new StringBuilder();
			for (var i = 0; i < 230807; i++)
			{
				sb.Append("a string");
				string dummy = sb.ToString();
				sb.Clear();
			}
		}
		void StringBuildInsert()
		{
			var sb = new StringBuilder();
			for (var i = 0; i < 230807; i++)
			{
				sb.Insert(0,"a string");
				string dummy = sb.ToString();
				sb.Clear();
			}
		}

		internal void RunDemo()
		{
			var sw = new Stopwatch();
			sw.Start();
			StringBuildAppend();
			sw.Stop();
			Console.WriteLine("It took {0}ms to append 230807 strings",sw.ElapsedMilliseconds);
			sw.Restart();
			StringBuildInsert();
			sw.Stop();
			Console.WriteLine("It took {0}ms to insert 230807 strings", sw.ElapsedMilliseconds);
			Console.WriteLine(
				"As of .Net 3.5 internal implementation of string builder was changed to linked list rather than array!");
		}
	}
}
