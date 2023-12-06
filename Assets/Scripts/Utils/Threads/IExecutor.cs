using Basement.OEPFramework.Futures;
using System;

namespace Utils.Threads
{
    public interface IExecutor
    {
        int TaskCount { get; }

        void Shutdown();

        IFuture Execute(Action action);

        IFuture Execute<T>(Func<T> func);

        T Execute<T>(T future) where T : IFuture;

        void Join();
    }
}