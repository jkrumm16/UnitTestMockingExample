using Infrastructure.Base;
using System;

namespace Infrastructure
{
    public class SubtractOperation : IServiceOperation, IEquatable<SubtractOperation>
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

        public override bool Equals(object obj)
        {
            return Equals(obj as SubtractOperation);
        }

        public override int GetHashCode()
        {
            var hashcode = 23;
            hashcode = (hashcode * 37) + NumberOne;
            hashcode = (hashcode * 37) + NumberTwo;
            return hashcode;
        }

        public bool Equals(SubtractOperation other)
        {
            return NumberOne == other.NumberOne && NumberTwo == other.NumberTwo;
        }
    }
}