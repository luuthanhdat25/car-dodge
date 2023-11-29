using RepeatUtil.DesignPattern.SingletonPattern;

using System;

namespace Moduler
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        public event Action<int> OnScoreChanged;
        
        private int currentScore;

        public void IncreaseScore(int score)
        {
            currentScore += score;
            OnScoreChanged?.Invoke(currentScore);
        }

        public int GetScore() => this.currentScore;
    }
}