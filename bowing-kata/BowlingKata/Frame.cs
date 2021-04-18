using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    class Frame
    {
        private const int LastFrameIndex = 9;

        private readonly int index;
        private List<KnockedDownPin> pins;

        public Frame(int index)
        {
            this.index = index;
            pins = new List<KnockedDownPin>();
        }

        public void AddThrow(KnockedDownPin value)
        {
            if (!CanAddPins())
            {
                throw new InvalidOperationException("Frame is already full");
            }

            pins.Add(value);
        }

        public bool CanAddPins()
        {
            if (IsLastFrame())
            {
                return pins.Count < 3;
            }

            return pins.Count < 2 && GetScore() < 10;
        }

        private bool IsLastFrame() => index == LastFrameIndex;

        public int GetScore()
        {
            var totalScore = pins.Sum(value => value.Value);
            if (IsLastFrame() && IsSecondThrowStrike())
            {
                totalScore += LastThrowScore();
            }

            return totalScore;
        }
        public bool ContainsFullScoreForStrike()
        {
            return !IsStrike() || pins.Count() == 2;
        }

        public int GetScoreForStrikeThrow()
        {
            if (!pins.Any())
            {
                return 0;
            }

            if (IsStrike())
            {
                return 10;
            }

            if (2 <= pins.Count)
            {
                return pins.Take(2).Sum(value => value.Value);
            }

            return FirstThrowScore();

        }

        public int FirstThrowScore()
        {
            if (!pins.Any())
            {
                return 0;
            }

            return pins.First().Value;
        }

        private int LastThrowScore()
        {
            if (!pins.Any())
            {
                return 0;
            }

            return pins.Last().Value;
        }

        private bool IsSecondThrowStrike()
        {
            if (2 <= pins.Count)
            {
                return pins[1].Value == 10;
            }

            return false;
        }

        public bool IsStrike()
        {
            if (!pins.Any())
            {
                return false;
            }

            return pins.First() == 10;
        }

        public bool IsSpare()
        {
            return !IsStrike() && GetScore() == 10;
        }
    }
}
