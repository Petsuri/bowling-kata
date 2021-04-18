using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class BowlingGame 
    {
        private int currentFrame = 0;
        private List<Frame> frames = new List<Frame>();

        public BowlingGame()
        {
            frames.Add(new Frame(currentFrame));
        }

        public void AddThrow(KnockedDownPin value)
        {
            if (!frames[currentFrame].CanAddPins())
            {
                currentFrame += 1;
                frames.Add(new Frame(currentFrame));
            }

            frames[currentFrame].AddThrow(value);
        }

        public int GetScore()
        {
            var totalScore = 0;
            for(int frameIndex = 0; frameIndex < frames.Count; frameIndex++)
            {
                totalScore += GetScoreForFrame(frameIndex);

            }

            return totalScore;
        }

        private int GetScoreForFrame(int frameIndex)
        {
            var frame = frames[frameIndex];
            if (frame.IsStrike())
            {
                return GetStrikeScores(frameIndex);
            }
            else if (frame.IsSpare())
            {
                return GetSpareScores(frameIndex);
            }

            return frame.GetScore();
        }

        private int GetStrikeScores(int strikeFrameIndex)
        {
            var currentFrame = frames[strikeFrameIndex];
            var score = currentFrame.GetScore();
            var firstFrame = strikeFrameIndex + 1;
            if (firstFrame < frames.Count())
            {
                var nextFrame = frames[firstFrame];
                score += nextFrame.GetScoreForStrikeThrow();
                if (nextFrame.ContainsFullScoreForStrike())
                {
                    return score;
                }
            }

            var secondFrame = strikeFrameIndex + 2;
            if (secondFrame < frames.Count())
            {
                score += frames[secondFrame].FirstThrowScore();
            }

            return score;
        }

        private int GetSpareScores(int spareFrameIndex)
        {
            var score = 10;
            var firstFrame = spareFrameIndex + 1;
            if (firstFrame < frames.Count())
            {
                score += frames[firstFrame].FirstThrowScore();
            }

            return score;
        }
    }
}
