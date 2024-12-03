var left = new List<int>();
var right = new List<int>();
var input = File.ReadAllLines("../../../input.txt");

foreach (var line in input)
{
    left.Add(Convert.ToInt32(line.Substring(0, 5)));
    right.Add(Convert.ToInt32(line.Substring(8, 5)));
}

left.Sort();
right.Sort();

var sum1 = 0;
var sum2 = 0;
for (var i = 0; i < left.Count; i++)
{
    sum1 += Math.Abs(left.ElementAt(i) - right.ElementAt(i));
    sum2 += left.ElementAt(i) * right.Count(x => x == left.ElementAt(i));
}

Console.WriteLine(sum1); // 1941353
Console.WriteLine(sum2); // 22539317
