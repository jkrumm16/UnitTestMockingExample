using Infrastructure.Base;

namespace Infrastructure
{
    public class SubtractOperation : IServiceOperation
    {
        public int NumberOne { get; set; }
        public int NumberTwo { get; set; }

        public SubtractOperation()
        {
        }

        public SubtractOperation(int numberOne, int numberTwo)
        {
            NumberOne = numberOne;
            NumberTwo = numberTwo;
        }
    }
}