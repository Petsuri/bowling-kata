using System;

namespace BowlingKata
{
    public sealed record KnockedDownPin
    {
        public int Value { get; }

        public KnockedDownPin(int numberOfPins)
        {
            if (numberOfPins < 0 || 10 < numberOfPins)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfPins), numberOfPins, "Is not valid number of knocked down pins");
            }

            Value = numberOfPins;
        }

        public bool IsStrike() => Value == 10;

        public static implicit operator KnockedDownPin(int value) => new KnockedDownPin(value);


    }
}
