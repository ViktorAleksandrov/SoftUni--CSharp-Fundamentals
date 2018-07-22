using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    private StringBuilder sb;

    public ConsoleWriter()
    {
        this.sb = new StringBuilder();
    }

    public string StoredMessage => this.sb.ToString().TrimEnd();

    public void StoreMessage(string message)
    {
        this.sb.AppendLine(message.TrimEnd());
    }

    public void WriteLine(string output)
    {
        Console.WriteLine(output);
    }
}
