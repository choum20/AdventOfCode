using Aoc12;
using System.Linq;

var donnees = System.IO.File.ReadAllLines("./Data.txt");

var split = donnees.Select(x => x.Split(new[] { ' ' },StringSplitOptions.None));

long reponse1 = 0;
foreach (var item in split)
{
	var pattern = $"{item.First()}?{item.First()}?{item.First()}?{item.First()}?{item.First()}";
	var counts = item.Last().Split(',').Select(x => int.Parse(x)).ToArray();
	counts = counts.Concat(counts).Concat(counts).Concat(counts).Concat(counts).ToArray();
	reponse1 += Etape1.Ways(pattern, counts);
}
Console.WriteLine(reponse1);

var reponse2 = Etape2.Execute();
Console.WriteLine(reponse2);

Console.ReadLine();