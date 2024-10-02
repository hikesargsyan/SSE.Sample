using FluentAssertions;
using FluentValidation.TestHelper;
using OneInc.Server.Application.Common.Constants;
using OneInc.Server.Application.TextProcessing.Commands.EncodeText;
using OneInc.Server.Application.TextProcessing.Commands.ProcessText;

namespace ApplicationTests;

public class EncodeTextTests
{

    [Theory]
    [InlineData("Hello, World!", " 1!1,1H1W1d1e1l3o2r1/SGVsbG8sIFdvcmxkIQ==")]
    [InlineData("a", "a1/YQ==")]
    public async Task Should_Return_Proper_Encoded_Data(string input, string output)
    {
        var commandHandler = new EncodeTextCommandHandler();

        var result = await commandHandler.Handle(new EncodeTextCommand(input), new CancellationToken());

        result.Should().Be(output);
    }
    
}
