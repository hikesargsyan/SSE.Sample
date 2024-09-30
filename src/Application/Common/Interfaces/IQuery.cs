namespace OneInc.Server.Application.Common.Interfaces;

public interface IQuery<out TResponse> : IRequest<TResponse> { }
