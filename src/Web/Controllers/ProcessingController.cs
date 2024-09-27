using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using OneInc.Server.Application.Processing.Commands.ProcessText;

namespace OneInc.Server.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ProcessingController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProcessingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async IAsyncEnumerable<char> ProcessText([FromBody] string text, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var processedText = await _mediator.Send(new ProcessTextCommand(text), cancellationToken);
        
        await foreach (var character in processedText.WithCancellation(cancellationToken))
        {
            yield return character;
        }
    }
}
