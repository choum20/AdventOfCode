using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc12
{
	internal static class Etape1
	{
		internal static long Ways(string pattern, int[] counts)
		{
			return Ways(pattern, counts, 0, 0, new Dictionary<(int, int), long>());
		}

		static long Ways(string pattern, int[] counts, int patternIndex, int countIndex, Dictionary<(int, int), long> waysMemo)
		{
			var memoKey = (patternIndex, countIndex);
			if (waysMemo.TryGetValue(memoKey, out var memo))
			{
				return memo;
			}

			if (patternIndex >= pattern.Length)
			{
				return countIndex == counts.Length ? 1 : 0;
			}

			long ways = 0;

			var currentPatternChar = pattern[patternIndex];
			if (currentPatternChar != '#') // either . so we skip it, or ? so consider what if we do skip it
			{
				ways += Ways(pattern, counts, patternIndex + 1, countIndex, waysMemo);
			}

			if (currentPatternChar != '.' && countIndex < counts.Length) // either # so we consume it, or ? so consider what if we do consume it
			{
				var enoughToConsume = true;
				var neededCount = counts[countIndex] - 1; // we've already got the first
				while (enoughToConsume && neededCount > 0)
				{
					patternIndex++;
					neededCount--;
					enoughToConsume = patternIndex < pattern.Length && pattern[patternIndex] != '.';
				}

				if (enoughToConsume)
				{
					var separatorIndex = patternIndex + 1;
					if (separatorIndex >= pattern.Length || pattern[separatorIndex] != '#')
					{
						ways += Ways(pattern, counts, separatorIndex + 1, countIndex + 1, waysMemo);
					}
				}
			}

			waysMemo.Add(memoKey, ways);
			return ways;
		}
	}
}
