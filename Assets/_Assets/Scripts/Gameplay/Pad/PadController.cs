using _Assets.Scripts.Services.Input;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Pad
{
	public class PadController
	{
		private readonly RectTransform _padRectTransform;
		private readonly Transform _padTransform;
		private readonly PlayerInput _playerInput;

		public PadController(Transform padTransform, PlayerInput playerInput)
		{
			_padTransform = padTransform;
			_playerInput = playerInput;
			_padRectTransform = (RectTransform)padTransform;
		}

		public void Move(float limitX)
		{
			Vector3 newPosition = _padTransform.position;
			newPosition.x = limitX + (limitX * _playerInput.PositionXNormalized) + (_padRectTransform.rect.width / 2);
			Debug.Log(_playerInput.PositionXNormalized);
			_padTransform.position = newPosition;
		}
	}
}
