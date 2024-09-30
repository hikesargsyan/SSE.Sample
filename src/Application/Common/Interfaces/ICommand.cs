namespace OneInc.Server.Application.Common.Interfaces;

public interface ICommand<out TResponse> : IRequest<TResponse> { }
