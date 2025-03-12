using _Assets.Scripts.Services.Input;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Pad
{
	public class PadView : MonoBehaviour
	{
		//TODO: use screen or rect width
		[SerializeField] private float limitX;
		private PadController _padController;
		[Inject] private PlayerInput _playerInput;

		private void Awake()
		{
			_padController = new PadController(transform, _playerInput);
		}

		private void Update()
		{
			_padController.Move(limitX);
		}
	}
}
