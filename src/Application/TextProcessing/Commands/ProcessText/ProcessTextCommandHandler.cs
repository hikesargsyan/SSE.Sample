using System.Runtime.CompilerServices;
using OneInc.Server.Application.Common.Interfaces;
using OneInc.Server.Application.TextProcessing.Commands.EncodeText;

namespace OneInc.Server.Application.TextProcessing.Commands.ProcessText;

public class ProcessTextCommandHandler : IRequestHandler<ProcessTextCommand, IAsyncEnumerable<char>>
{
    private readonly IMediator _mediator;
    private readonly ICacheService _cacheService;

    public ProcessTextCommandHandler(IMediator mediator, ICacheService cacheService)
    {
        _mediator = mediator;
        _cacheService = cacheService;
    }

    public async Task<IAsyncEnumerable<char>> Handle(ProcessTextCommand request, CancellationToken cancellationToken)
    {
        var encodedText = await _cacheService.GetAsync<string>(
            request.Text,
            async () => await _mediator.Send(new EncodeTextCommand(request.Text), cancellationToken),
            cancellationToken
        );

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
