using System;
using UnityEngine;

namespace GoldSystem
{
    public class Gold 
    {
        public const int StartValue = 6;
        private const int EndValue = 0;
        
        public int GoldValue { get; private set; }

        public event Action<int> OnScoreChange;
        public void ResetScore()
        {
            GoldValue = EndValue;
            OnScoreChange?.Invoke(GoldValue);
        }
        public void SetUpScore()
        {
            Debug.Log("1");
            GoldValue = StartValue;
            OnScoreChange?.Invoke(GoldValue);
        }

        public void AddScore(int adding)
        {
            GoldValue += adding;
            OnScoreChange?.Invoke(GoldValue);
        }
    }
}
