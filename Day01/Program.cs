var solution = 0;
var inputs = File.ReadAllLines("input.txt").ToList();

Console.WriteLine("Starting Day 1");
Part1();
solution = 0;
Part2();
Console.WriteLine("Ending Day 1");
return;

void Part1()
{
    var pos = 50;
    foreach(var line in inputs)
    {
        var dir = line[0];
        var count = int.Parse(line[1..]);
        
        if (dir == 'R') pos += count;
        else if (dir == 'L') pos -= count;
        else break;

        // Proper modulo to keep pos in [0, 99]
        pos = (pos % 100 + 100) % 100;
        if(pos == 0) solution++;
    }
    Console.WriteLine("Part 1 solution = " + solution);
}

    void Part2()
    {
        var pos = 50;
        foreach(var line in inputs)
        {
            var dir = line[0];
            var count = int.Parse(line[1..]);
            
            if (dir == 'R')
            {
                // Crossing point: (pos + count) / 100
                solution += (pos + count) / 100;
                pos = (pos + count) % 100;
            }
            else // dir == 'L'
            {
                if (pos > 0 && count >= pos) // Only count the first crossing if we weren't already at 0
                {
                    solution += 1 + (count - pos) / 100;
                }
                else if (pos == 0 && count >= 100) // If at 0, we need 100 to cross it again
                {
                    solution += count / 100;
                }
                pos = (pos - (count % 100) + 100) % 100;
            }
        }
        Console.WriteLine("Part 2 solution = " + solution);
    }