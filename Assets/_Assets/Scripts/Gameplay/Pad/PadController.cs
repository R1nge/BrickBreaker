using _Assets.Scripts.Services.Input;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Pad
{
	public class PadController
	{
		private readonly Transform _padTransform;
		private readonly PlayerInput _playerInput;

		public PadController(Transform padTransform, PlayerInput playerInput)
		{
			_padTransform = padTransform;
			_playerInput = playerInput;
		}

		public void Move()
		{
			Vector3 newPosition = _padTransform.position;
			newPosition.x = _playerInput.PositionX;
			_padTransform.position = newPosition;
		}
	}
}
