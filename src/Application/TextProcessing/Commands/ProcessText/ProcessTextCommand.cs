
namespace OneInc.Server.Application.TextProcessing.Commands.ProcessText;

public class ProcessTextCommand : ICommand<IAsyncEnumerable<char>>
{
    public ProcessTextCommand(string text)
    {
        Text = text;
    }

    public string Text { get; }
}
