using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc08
{
	internal static class Etape1
	{
		public static ParcoursResult Execute(char[] instructions, IEnumerable<Coordonnee> coordonnes)
		{
			var lastParcours = new ParcoursResult()
			{
				Compteur = 0,
				Direction = "AAA"
			};
			do
			{
				lastParcours = Helper.GetParcoursResult(instructions, coordonnes, lastParcours);

			} while (lastParcours.Direction != "ZZZ");

			return lastParcours;
		}
	}
}
