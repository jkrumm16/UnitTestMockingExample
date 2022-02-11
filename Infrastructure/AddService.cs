using Infrastructure.Base;

namespace Infrastructure
{
    public class AddService : ExtensionsServiceBase
    {
        public override int Calculate(int numberOne, int numberTwo)
        {
            var addOperation = new AddOperation
            {
                NumberOne = numberOne,
                NumberTwo = numberTwo
            };

            return Owner.Execute(addOperation);
        }
    }
}