using System;
using UnityEngine;

namespace _Assets.Scripts.Services.Score
{
	public class ScoreHolder
	{
		private int _currentScore;

		public int CurrentScore
		{
			get => _currentScore;
			private set
			{
				_currentScore = value;
				OnScoreChanged?.Invoke(_currentScore);
			}
		}

		public event Action<int> OnScoreChanged;

		public void AddPoints(int score)
		{
			if (score <= 0)
			{
				Debug.LogWarning($"Trying to add {score}");
				return;
			}

			CurrentScore += score;
		}

		public void ResetPoints() => CurrentScore = 0;
	}
}
