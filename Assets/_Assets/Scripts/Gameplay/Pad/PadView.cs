using _Assets.Scripts.Services.Input;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Pad
{
	public class PadView : MonoBehaviour
	{
		private PadController _padController;
		[Inject] private PlayerInput _playerInput;

		private void Awake()
		{
			_padController = new PadController(transform, _playerInput);
		}

		private void Update()
		{
			_padController.Move();
		}
	}
}
