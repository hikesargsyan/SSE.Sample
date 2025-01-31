using System.Runtime.CompilerServices;
using App.Application.TextProcessing.Commands.EncodeText;
using App.Application.Common.Interfaces;

namespace App.Application.TextProcessing.Commands.ProcessText;

public class ProcessTextCommandHandler(IMediator mediator) : IRequestHandler<ProcessTextCommand, IAsyncEnumerable<char>>
{
    public async Task<IAsyncEnumerable<char>> Handle(ProcessTextCommand request, CancellationToken cancellationToken)
    {
        var encodedText = await mediator.Send(new EncodeTextCommand(request.Text), cancellationToken);

        return ProcessTextAsync(encodedText, cancellationToken);
    }

    private async IAsyncEnumerable<char> ProcessTextAsync(
        string text,
        [EnumeratorCancellation] CancellationToken cancellationToken
    )
    {
        foreach (var character in text)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                yield break;
            }

            await SimulateLongRunningTask(cancellationToken);
            yield return character;
        }
    }

    private async Task SimulateLongRunningTask(CancellationToken cancellationToken)
    {
        await Task.Delay(new Random().Next(1000, 5000), cancellationToken);
    }
}
