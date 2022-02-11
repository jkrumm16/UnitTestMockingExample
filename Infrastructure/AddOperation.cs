using Infrastructure.Base;
using System;

namespace Infrastructure
{
    public class AddOperation : IServiceOperation, IEquatable<AddOperation>
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

        public override bool Equals(object obj)
        {
            return Equals(obj as AddOperation);
        }

        public override int GetHashCode()
        {
            var hashcode = 23;
            hashcode = (hashcode * 37) + NumberOne;
            hashcode = (hashcode * 37) + NumberTwo;
            return hashcode;
        }

        public bool Equals(AddOperation other)
        {
            return NumberOne == other.NumberOne && NumberTwo == other.NumberTwo;
        }
    }
}