namespace OneInc.Server.Application.Processing.Commands.ProcessText;

public class ProcessTextCommand : IRequest<IAsyncEnumerable<char>>
{
    public ProcessTextCommand(string text)
    {
        Text = text;
    }

    public string Text { get; }
}
