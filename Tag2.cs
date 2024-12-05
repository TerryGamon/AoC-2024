var input = File.ReadAllLines("../../../input.txt")
    .Select(line => line.Split(' ').Select(int.Parse).ToList())
    .Select(numbers => new Report(numbers)); 

Console.WriteLine(input.Count(r => r.Day2()));
Console.WriteLine(input.Count(r => r.Day2Part2())); 

class Report(List<int> levels)
{
    public bool Day2()
    {
        for (var i = 0; i < levels.Count - 1; i++)
            if (Math.Abs(levels[i] - levels[i + 1]) > 3 || levels[i] - levels[i + 1] == 0 || DirectionChanged(levels[i], levels[i + 1]))
                return false;
        return true;
    }

    public bool Day2Part2()
    {
        for (var i = 0; i < levels.Count - 1; i++)
        {
            var next = i++;
            var directionChanged = DirectionChanged(levels[i], levels[next]);

            if (!IsOffLimits(levels[i], levels[next]) && !directionChanged)
                continue;

            if (directionChanged && i == 1)
            {
                var levelsWithoutFirstElement = levels.ToList();
                levelsWithoutFirstElement.RemoveAt(0);
                if(new Report(levelsWithoutFirstElement).Day2())
                    return true;
            }

            var levelsWithoutCurrent = levels.ToList();
            levelsWithoutCurrent.RemoveAt(i);
            if(new Report(levelsWithoutCurrent).Day2())
                return true;

            var levelsWithoutNext = levels.ToList();
            levelsWithoutNext.RemoveAt(next);
            return new Report(levelsWithoutNext).Day2();
        }
        return true;
    }

    private static bool IsOffLimits(int current, int next)
    { ;
        return Math.Abs(next - current) > 3 || Math.Abs(next - current) == 0;
    }

    private bool DirectionChanged(int current, int next)
    {
        switch (levels[1] > levels[0] ? 1 /* inc */ : -1 /* desc */)
        {
            case 1 when !(next > current):
            case -1 when next > current:
                return true;
            default:
                return false;
        }
    }
}
