using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
	class Program
	{
		static void Main(string[] args)
		{
			bool[,] map = new bool[4, 4] { { false, true, false, false }, { true, false, true, true }, { false, true, false, true }, { false, true, true, false } };
			int k = 2;
			List<int> covered = new List<int>();
			int current = 0;
			Console.WriteLine(CanBeCovered(map, k, covered, current));
		}

		static bool CanBeCovered(bool[,] map, int k, List<int> covered, int current)
		{
			if (covered.Count > k)
			{
				return false;
			}
			if (IsCovered(map, covered))
			{
				return true;
			}

			int vertex = current;

			for (int marked = 0; marked < k; marked++)
			{
				covered.Add(vertex);
				if (CanBeCovered(map, k, covered, current + 1))
					{
						return true;
					}
				covered.Remove(vertex);
			}
			return false;
		}

		static bool IsCovered(bool[,] map, List<int> covered)
		{
			if (covered.Count == 0)
			{
				return false;
			}
			for (int vertex = 0; vertex < map.GetLength(0); vertex++)
			{
				for (int vertex2 = 0; vertex2 < map.GetLength(0); vertex2++)
				{
					if (map[vertex, vertex2] && (!covered.Contains(vertex) && !covered.Contains(vertex2)))
					{
						return false;
					}
				}
			}
			return true;
		}


	}
}
