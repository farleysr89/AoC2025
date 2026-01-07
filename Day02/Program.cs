long solution = 0;
var inputs = File.ReadAllLines("input.txt")[0].Split(",") ;

Console.WriteLine("Starting Day 2");
Part1();
solution = 0;
Part2();
Console.WriteLine("Ending Day 2");
return;

void Part1()
{
    foreach (var line in inputs)
    {
        var vals = line.Split("-");
        for (var i = long.Parse(vals[0]); i <= long.Parse(vals[1]); i++)
        {
            var tmp = i.ToString();
            var size = tmp.Length / 2;
            if (tmp[0..size] == tmp[size..]) solution += i;
        }

    }
    Console.WriteLine("Part 1 solution = " + solution);
    return;
}

void Part2()
{
    foreach (var line in inputs)
    {
        var vals = line.Split("-");
        for (var i = long.Parse(vals[0]); i <= long.Parse(vals[1]); i++)
        {
            var tmp = i.ToString();
            var len = tmp.Length;
                    
            // A string is made of identical substrings if a prefix of length 'l'
            // repeats 'len / l' times to reconstruct the original string.
            // 'l' can be at most len / 2 because we need at least 2 substrings.
            for (var l = 1; l <= len / 2; l++)
            {
                if (len % l == 0)
                {
                    var sub = tmp[..l];
                    if (string.Concat(Enumerable.Repeat(sub, len / l)) == tmp)
                    {
                        solution += i;
                        break;
                    }
                }
            }
        }
    }
    Console.WriteLine("Part 2 solution = " + solution);
}