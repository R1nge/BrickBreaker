using _Assets.Scripts.Services.StateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Assets.Scripts.Services.Brick
{
	public class BrickAmountChecker
	{
		private readonly GameStateMachine _gameStateMachine;

		private int _currentBricks;

		private BrickAmountChecker(GameStateMachine gameStateMachine)
		{
			_gameStateMachine = gameStateMachine;
		}

		public void Add(int amount)
		{
			if (amount <= 0)
			{
				Debug.LogWarning($"[BrickAmountChecker] Trying to add {amount}");
				return;
			}

			_currentBricks += amount;
		}

		public void Remove(int amount)
		{
			if (amount <= 0)
			{
				Debug.LogWarning($"[BrickAmountChecker] Trying to remove {amount}");
				return;
			}

			_currentBricks -= amount;

			if (_currentBricks <= 0)
			{
				_gameStateMachine.SwitchState(GameStateType.Win).Forget();
			}
		}
	}
}
