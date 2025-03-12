using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.Input;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Pad
{
	public class PadView : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer spriteRenderer;
		[SerializeField] private float limitX;
		[SerializeField] private Transform ballSpawnPoint;
		[Inject] private BallFactory _ballFactory;
		private PadController _padController;
		[Inject] private PlayerInput _playerInput;

		private void Awake() => _padController = new PadController(transform, spriteRenderer, _playerInput);

		private void Start() => _ballFactory.Create(ballSpawnPoint.position, ballSpawnPoint);

		private void Update() => _padController.Move(limitX);
	}
}
