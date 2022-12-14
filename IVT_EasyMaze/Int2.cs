namespace IVT_EasyMaze;

public record Int2(int X, int Y)
{
    public static Int2 operator +(Int2 a, Int2 b)
        => new(a.X + b.X, a.Y + b.Y);
    public static Int2 operator -(Int2 a, Int2 b)
        => new(a.X - b.X, a.Y - b.Y);
}