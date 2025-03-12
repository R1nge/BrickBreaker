using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.Input;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Pad
{
	public class PadView : MonoBehaviour
	{
		//TODO: use screen or rect width
		[SerializeField] private float limitX;
		[SerializeField] private Transform ballSpawnPoint;
		[Inject] private BallFactory _ballFactory;
		private PadController _padController;
		[Inject] private PlayerInput _playerInput;

		private void Awake() => _padController = new PadController(transform, _playerInput);

		private void Start() => _ballFactory.Create(ballSpawnPoint.position, ballSpawnPoint.root);

		private void Update() => _padController.Move(limitX);
	}
}
