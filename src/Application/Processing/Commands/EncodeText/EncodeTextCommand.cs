namespace OneInc.Server.Application.Processing.Commands.EncodeText;

public class EncodeTextCommand : IRequest<string>
{
    public EncodeTextCommand(string text)
    {
        Text = text;
    }

    public string Text { get; }
}
