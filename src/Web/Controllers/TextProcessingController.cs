using MediatR;
using Microsoft.AspNetCore.Mvc;
using OneInc.Server.Application.TextProcessing.Commands.ProcessText;

namespace OneInc.Server.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TextProcessingController : ControllerBase
{
    private readonly IMediator _mediator;

    public TextProcessingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{text}")]
    public async Task ProcessText(string text, CancellationToken cancellationToken)
    {
        var processedText = await _mediator.Send(new ProcessTextCommand(text), cancellationToken);

        Response.ContentType = "text/event-stream";
        await foreach (var message in processedText.WithCancellation(cancellationToken))
        {
            await Response.WriteAsync(ConvertCharToEventData(message), cancellationToken: cancellationToken);
            await Response.Body.FlushAsync(cancellationToken);
        }
    }

    private string ConvertCharToEventData(char character)
    {
        return $"data: {character}\n\n";
    }
}
