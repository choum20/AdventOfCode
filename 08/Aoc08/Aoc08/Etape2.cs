using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Aoc08
{
	internal static class Etape2
	{
		public static BigInteger Execute(char[] instructions, IEnumerable<Coordonnee> coordonnes)
		{
			var allStarts = coordonnes.Where(_ => _.Start!.EndsWith('A'));
			var results = allStarts.Select(a => new ParcoursResult() { Direction = a.Start, Compteur = 0 }).ToList();

			foreach (var item in results)
			{
				Helper.GetParcoursResult(instructions, coordonnes, item);
			}

			for (int i = 0; i < results.Count - 1; i++)
			{
				results[i + 1].Compteur = Helper.Ppcm(results[i].Compteur, results[i + 1].Compteur);
			}

			return results.Last().Compteur;
		}
	}
}
// Atteint 2619324