using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Assets.Scripts.Services.Input
{
	public class PlayerInputView : MonoBehaviour
	{
		[SerializeField] private Slider slider;
		[Inject] private PlayerInput _playerInput;

		private void Update() => SetPositionX();

		public void SetPositionX() => _playerInput.SetPlayerPositionX(slider.value);
	}
}
