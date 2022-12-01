using Day1;
using System.Globalization;

bool running = true;

List<Elf> elfs = new List<Elf>();
Elf elfCarryingMost = null;
new Thread(() =>
{
    List<int> tmp = new List<int>();

    foreach (string line in File.ReadAllLines("input.txt"))
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            int i = 0;

            foreach (int io in tmp)
                i += io;

            elfs.Add(new Elf(tmp));
            tmp.Clear();
            continue;
        }

        tmp.Add(int.Parse(line));
    }

    Tuple<Elf, int> lastMost = new Tuple<Elf, int>(null, 0);

    foreach (Elf elf in elfs)
    {
        if (lastMost.Item2 < elf.GetCals)
        {
            lastMost = new Tuple<Elf, int>(elf, elf.GetCals);
        }
    }

    elfCarryingMost = lastMost.Item1;

    // Appreciate the effect
    Thread.Sleep(5000);

    running = false;
}).Start();

Random r = new Random();

Console.WriteLine(Console.BufferWidth + "");
Console.WriteLine(Console.BufferHeight + "");
Console.BufferWidth = 120;
Console.BufferHeight = 9001;

while(running) 
{
    Console.ForegroundColor = ConsoleColor.Green;
    for (int i = 0; i < Console.BufferWidth; i += 30)
    {
        try
        {
            Console.SetCursorPosition(r.Next(i, i + 30), r.Next(0, Console.WindowHeight));
            Console.Write((char)r.Next(0, 255));
        }catch(ArgumentOutOfRangeException) { }
    }

    Console.ForegroundColor = ConsoleColor.Red;
    Console.SetCursorPosition((Console.WindowWidth / 2) - ((":::HACKING THE SYSTEM:::").Length / 2), Console.WindowHeight / 2);
    Console.Write(":::HACKING THE SYSTEM:::");
    new Thread(() => Console.Beep(600, 10)).Start();
}
Console.Clear();
Console.SetCursorPosition(0, 0);

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Elf Carrying most is Elf #" + elfs.IndexOf(elfCarryingMost) + " with " + elfCarryingMost.GetCals + " calories!");
Console.ReadKey();