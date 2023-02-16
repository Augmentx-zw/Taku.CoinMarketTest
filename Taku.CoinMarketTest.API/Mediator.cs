using Taku.CoinMarketTest.Domain.CommandHandler;
using Taku.CoinMarketTest.Domain.QueryHandlers;

namespace Taku.CoinMarketTest.API
{
    public class Mediator
    {
        private readonly IServiceProvider _provider;

        public Mediator(IServiceProvider provider)
        {
            _provider = provider;
        }

        public void Dispatch(ICommand command)
        {
            using (IServiceScope scope = _provider.CreateScope())
            {
                Type type = typeof(ICommandHandler<>);
                Type[] typeArgs = { command.GetType() };
                //We are converting to generic using reflection
                Type handlerType = type.MakeGenericType(typeArgs);

                //makes u be able to use diffrent classes ie my commands
                dynamic handler = scope.ServiceProvider.GetRequiredService(handlerType);
                handler.Handle((dynamic)command);
            }
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            using (IServiceScope scope = _provider.CreateScope())
            {
                Type type = typeof(IQueryHandler<,>);
                Type[] typeArgs = { query.GetType(), typeof(T) };
                Type handlerType = type.MakeGenericType(typeArgs);

                dynamic handler = scope.ServiceProvider.GetRequiredService(handlerType);
                T result = handler.Handle((dynamic)query);

                return result;
            }
        }
    }
}

