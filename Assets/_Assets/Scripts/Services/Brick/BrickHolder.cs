using System.Collections.Generic;
using _Assets.Scripts.Services.StateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Assets.Scripts.Services.Brick
{
	public class BrickHolder
	{
		private readonly List<GameObject> _bricks = new List<GameObject>();
		private readonly GameStateMachine _gameStateMachine;

		private BrickHolder(GameStateMachine gameStateMachine) => _gameStateMachine = gameStateMachine;

		public void Add(GameObject gameObject)
		{
			_bricks.Add(gameObject);
		}

		public void Remove(GameObject gameObject)
		{
			_bricks.Remove(gameObject);
			if (_bricks.Count <= 0)
			{
				_gameStateMachine.SwitchState(GameStateType.Win).Forget();
			}
		}

		public void Reset()
		{
			int length = _bricks.Count;
			for (int i = length - 1; i >= 0; i--)
			{
				Object.Destroy(_bricks[i]);
			}

			_bricks.Clear();
		}
	}
}
