using Infrastructure.Base;

namespace Infrastructure
{
    public class AddOperation : IServiceOperation
    {
        public int NumberOne { get; set; }
        public int NumberTwo { get; set; }

        public AddOperation()
        {
        }

        public AddOperation(int numberOne, int numberTwo)
        {
            NumberOne = numberOne;
            NumberTwo = numberTwo;
        }
    }
}