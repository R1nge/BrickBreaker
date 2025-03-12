using _Assets.Scripts.Services.Input;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Pad
{
	public class PadController
	{
		private readonly PlayerInput _playerInput;
		private readonly SpriteRenderer _spriteRenderer;
		private readonly Transform _transform;

		public PadController(Transform transform, SpriteRenderer spriteRenderer, PlayerInput playerInput)
		{
			_transform = transform;
			_spriteRenderer = spriteRenderer;
			_playerInput = playerInput;
		}

		public void Move(float limitX)
		{
			Vector3 newPosition = _transform.position;
			newPosition.x = limitX * _playerInput.PositionXNormalized;
			_transform.position = newPosition;
		}
	}
}
