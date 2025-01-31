
namespace App.Application.TextProcessing.Commands.EncodeText;

public record EncodeTextCommand(string Text) : ICommand<string>;
