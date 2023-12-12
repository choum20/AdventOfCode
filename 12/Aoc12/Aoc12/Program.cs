using Aoc12;

var donnees = System.IO.File.ReadAllLines("./Data.txt");



var reponse1 = Etape1.Execute();
Console.WriteLine(reponse1);

var reponse2 = Etape2.Execute();
Console.WriteLine(reponse2);

Console.ReadLine();