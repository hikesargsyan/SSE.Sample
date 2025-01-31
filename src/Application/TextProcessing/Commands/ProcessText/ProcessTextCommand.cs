
using App.Application.Common.Interfaces;

namespace App.Application.TextProcessing.Commands.ProcessText;

public record ProcessTextCommand(string Text) : ICommand<IAsyncEnumerable<char>>;
