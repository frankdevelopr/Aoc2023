namespace Aoc2023Day19;

public class Part
{
    public long X { get; set; }
    public long M { get; set; }
    public long A { get; set; }
    public long S { get; set; }
    public long Rating { get; }

    public Part(long x, long m, long a, long s)
    {
        X = x;
        M = m;
        A = a;
        S = s;

        Rating = x + m + a + s;
    }
}
