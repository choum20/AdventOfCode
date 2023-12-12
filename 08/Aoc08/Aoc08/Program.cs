using Aoc08;

var donnees = System.IO.File.ReadAllLines("./Data.txt");

var instructions = donnees.First().ToArray();

var coordonnes = donnees.Skip(2).Select(x => new Coordonnee() { Start = new string(x.Take(3).ToArray()), Left = new string(x.Take(new Range(7, 10)).ToArray()), Right = new string(x.Take(new Range(12, 15)).ToArray()) });


//var reponse1 = Etape1.Execute(instructions, coordonnes);
//Console.WriteLine(reponse1.Direction);
//Console.WriteLine(reponse1.Compteur);

var reponse2 = Etape2.Execute(instructions, coordonnes);
Console.WriteLine(reponse2);

Console.ReadLine();
