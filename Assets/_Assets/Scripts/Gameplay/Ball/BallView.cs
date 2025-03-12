using _Assets.Scripts.Services.StateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Ball
{
	public class BallView : MonoBehaviour
	{
		[SerializeField] private float maxVelocity = 500f;
		[SerializeField] private new Rigidbody2D rigidbody2D;
		[SerializeField] private float reflectionForce = 500f;
		[SerializeField] private float gravityForce;
		[Inject] private GameStateMachine _gameStateMachine;
		private Vector3 _lastFrameVelocity;

		private void Start()
		{
			rigidbody2D.AddForce(Vector2.down * reflectionForce * rigidbody2D.mass, ForceMode2D.Impulse);
		}

		private void Update() => _lastFrameVelocity = rigidbody2D.velocity;

		private void FixedUpdate()
		{
			rigidbody2D.AddForce(Vector2.down * (gravityForce * rigidbody2D.mass));
			var clampX = Mathf.Clamp(rigidbody2D.velocity.x, -maxVelocity, maxVelocity);
			var clampY = Mathf.Clamp(rigidbody2D.velocity.y, -maxVelocity, maxVelocity);
			rigidbody2D.velocity = new Vector2(clampX, clampY);
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			var reflectionDirection = Vector2.Reflect(_lastFrameVelocity, other.contacts[0].normal);
			rigidbody2D.AddForce(reflectionDirection * reflectionForce * rigidbody2D.mass, ForceMode2D.Impulse);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			_gameStateMachine.SwitchState(GameStateType.Gameover).Forget();
		}
	}
}
