using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Aoc08
{
	internal static class Helper
	{
		internal static string? GetNextStep(IEnumerable<Coordonnee> coordonnes, string? start, char instruction)
		{
			var coordonne = coordonnes.Single(c => c.Start == start);
			return instruction == 'L' ? coordonne.Left : coordonne.Right;
		}

		internal static ParcoursResult GetParcoursResult(char[] instructions, IEnumerable<Coordonnee> coordonnes, ParcoursResult? direction)
		{
			var nbrInstructions = instructions.Length;
			var iterator = 0;
			do
			{
				direction!.Direction = GetNextStep(coordonnes, direction.Direction, instructions[iterator]);
				iterator++;
				if (iterator >= nbrInstructions)
					iterator = 0;
				direction.Compteur++;

			} while (direction.Direction!.ToCharArray().Last() != 'Z');

			return direction;
		}

		internal static BigInteger Ppcm(BigInteger a, BigInteger b)
		{
			BigInteger p = a * b;
			while (a != b) if (a < b) b -= a; else a -= b;
			return p / a;
		}
	}
}
