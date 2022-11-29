namespace IVT_EasyMaze;

public class DrawService
{
    private readonly Dictionary<int, ConsoleColor> tileColors = new()
    {
        {0,ConsoleColor.White},
        {1,ConsoleColor.DarkGray},
        {2,ConsoleColor.Green},
        {3,ConsoleColor.Blue},
        {4,ConsoleColor.DarkBlue},
        {5,ConsoleColor.Red},
        {6,ConsoleColor.DarkRed},
        {7,ConsoleColor.Yellow},
        {8,ConsoleColor.DarkYellow},
        {9,ConsoleColor.Magenta},
    };
    public void DrawTile(int tileValue, Int2 position)
    {
        int tileColorValue = tileValue % tileColors.Count;
        var color = tileColors[tileColorValue];
        Console.ForegroundColor = color;
        Console.SetCursorPosition(position.X*2,position.Y);
        Console.Write(tileColorValue);
    }

    public void DrawPlayer(int tileValue, Int2 position)
    {
        int tileColorValue = tileValue % tileColors.Count;
        var color = tileColors[tileColorValue];
        Console.ForegroundColor = color;
        Console.SetCursorPosition(position.X * 2, position.Y);
        Console.Write("P");
    }

    //private ConsoleColor ColorFromTileValue(int tileValue)
    //{
    //    int tileColorValue = tileValue % tileColors.Count;
    //    var color = tileColors[tileColorValue];
    //    return color;
    //}
}