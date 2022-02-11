using Infrastructure.Base;

namespace Infrastructure
{
    public class SubtractService : ExtensionsServiceBase
    {
        public int Subtract(int numberOne, int numberTwo)
        {
            var subtractOperation = new SubtractOperation
            {
                NumberOne = numberOne,
                NumberTwo = numberTwo
            };

            return Owner.Execute(subtractOperation);
        }
    }
}