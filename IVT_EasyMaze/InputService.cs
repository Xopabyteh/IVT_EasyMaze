namespace IVT_EasyMaze;

public class InputService
{
    private List<ConsoleKeyInfo> messageList;

    public InputService()
    {
        messageList = new List<ConsoleKeyInfo>();
        var readThread = new Thread(ReadMessages)
        {
            IsBackground = true
        };
        readThread.Start();
    }

    private void ReadMessages()
    {
        while (true)
        {
            var msg = Console.ReadKey(true);
            lock (messageList)
            {
                messageList.Add(msg);
            }
        }
    }
    /// <summary>
    /// Returns the current message List and clears it
    /// </summary>
    /// <returns></returns>
    public IEnumerable<ConsoleKeyInfo> ReadQueue()
    {
        List<ConsoleKeyInfo> listCopy;
        lock (messageList)
        {
            listCopy = new List<ConsoleKeyInfo>(messageList);
            messageList.Clear();
        }
        return listCopy;
    }
}