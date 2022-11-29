namespace IVT_EasyMaze;

public class ConsoleHelper
{

    /// <summary>
    /// Writes prompt + ":" and then gets an integer from the console
    /// </summary>
    /// <param name="prompt"></param>
    /// <returns></returns>
    public int ReadValuePrompt(string prompt)
    {
        Console.Write($"{prompt}: ");
        var read = Console.ReadLine();
        if (int.TryParse(read, out var res))
            return res;

        return ReadValuePrompt(prompt);
    }
}