var donnees = System.IO.File.ReadAllLines("./Data.txt");
var somme = 0;

var getLetterArray = new Dictionary<string, string>()
    {
        {"one", "1"},
        {"two", "2"},
        {"three", "3"},
        {"four", "4"},
        {"five", "5"},
        {"six", "6"},
        {"seven", "7"},
        {"eight", "8"},
        {"nine", "9"}
    };

foreach (var donne in donnees)
{
    if (string.IsNullOrEmpty(donne)) continue;

    var position = new List<Position>();

    foreach (var item in getLetterArray)
    {
        var indexKeyList = donne.AllIndexesOf(item.Key);
        foreach (var indexKey in indexKeyList)
        {
            if (indexKey > -1)
                position.Add(new Position() { Litteral = indexKey, Numeric = getLetterArray[item.Key] });
        }
        var indexValueList = donne.AllIndexesOf(item.Value);
        foreach (var indexValue in indexValueList)
        {
            if (indexValue > -1)
                position.Add(new Position() { Litteral = indexValue, Numeric = item.Value });
        }
    }

    var first = position.OrderBy(x => x.Litteral).First().Numeric;
    var last = position.OrderBy(x => x.Litteral).Last().Numeric;
    var result = first + last;

    somme += int.Parse(result);
}

Console.WriteLine(somme);
Console.ReadLine();

public static class Extension
{

    public static List<int> AllIndexesOf(this string str, string value)
    {
        if (String.IsNullOrEmpty(value))
            throw new ArgumentException("the string to find may not be empty", "value");
        List<int> indexes = new List<int>();
        for (int index = 0; ; index += value.Length)
        {
            index = str.IndexOf(value, index);
            if (index == -1)
                return indexes;
            indexes.Add(index);
        }
    }

}

public class Position
{
    public int Litteral { get; set; }
    public string? Numeric { get; set; } = string.Empty;
}