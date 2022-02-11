using Infrastructure.Base;
using System;
using System.Diagnostics;

namespace Infrastructure
{
    public class SimpleMathService : ServiceBase
    {
        public override int Execute(IServiceOperation operation)
        {
            switch (operation)
            {
                case AddOperation addOperation:
                    return addOperation.NumberOne + addOperation.NumberTwo;

                case SubtractOperation subtractOperation:
                    return subtractOperation.NumberOne - subtractOperation.NumberTwo;

                default:
                    throw new ArgumentException(nameof(operation));
            }
        }
    }
}