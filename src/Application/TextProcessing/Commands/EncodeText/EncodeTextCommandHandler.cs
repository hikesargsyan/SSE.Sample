using System.Text;
using App.Application.Common.Interfaces;

namespace App.Application.TextProcessing.Commands.EncodeText;

public class EncodeTextCommandHandler : IRequestHandler<EncodeTextCommand, string>
{
    public Task<string> Handle(EncodeTextCommand request, CancellationToken cancellationToken)
    {
        var charsCountMap = new Dictionary<char, int>();
        
        foreach (var c in request.Text)
        {
            if (!charsCountMap.TryAdd(c, 1))
            {
                charsCountMap[c]++;
            }
        }

        var resultBuilder = new StringBuilder();
        foreach (var kvp in charsCountMap.OrderBy(kvp => kvp.Key))
        {
            resultBuilder
                .Append(kvp.Key)
                .Append(kvp.Value);
        }

        var base64Encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(request.Text));

        resultBuilder
            .Append('/')
            .Append(base64Encoded);
        
        return Task.FromResult(resultBuilder.ToString());
    }
}
