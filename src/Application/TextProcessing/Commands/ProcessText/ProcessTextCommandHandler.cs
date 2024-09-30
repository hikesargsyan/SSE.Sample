using System.Runtime.CompilerServices;
using OneInc.Server.Application.Common.Interfaces;
using OneInc.Server.Application.TextProcessing.Commands.EncodeText;

namespace OneInc.Server.Application.TextProcessing.Commands.ProcessText;

public class ProcessTextCommandHandler : IRequestHandler<ProcessTextCommand, IAsyncEnumerable<char>>
{
    private readonly IMediator _mediator;

    public ProcessTextCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IAsyncEnumerable<char>> Handle(ProcessTextCommand request, CancellationToken cancellationToken)
    {
        var encodedText = await _mediator.Send(new EncodeTextCommand(request.Text), cancellationToken);

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
