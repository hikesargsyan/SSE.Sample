
namespace OneInc.Server.Application.TextProcessing.Commands.EncodeText;

public class EncodeTextCommand : ICommand<string>
{
    public EncodeTextCommand(string text)
    {
        Text = text;
    }

    public string Text { get; }
}
