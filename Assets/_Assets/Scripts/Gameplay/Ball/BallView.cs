using System.Collections;
using _Assets.Scripts.Gameplay.Brick;
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
		private bool _canCollide = true;
		[Inject] private GameStateMachine _gameStateMachine;
		private Vector3 _lastFrameVelocity;

		private void Start()
		{
			rigidbody2D.velocity = Vector2.down * maxVelocity;
			_lastFrameVelocity = rigidbody2D.velocity;
		}

		private void Update() => _lastFrameVelocity = rigidbody2D.velocity;

		private void FixedUpdate()
		{
			rigidbody2D.AddForce(Vector2.down * (gravityForce * rigidbody2D.mass));
			float clampX = Mathf.Clamp(rigidbody2D.velocity.x, -maxVelocity, maxVelocity);
			float clampY = Mathf.Clamp(rigidbody2D.velocity.y, -maxVelocity, maxVelocity);
			rigidbody2D.velocity = new Vector2(clampX, clampY);
		}

		private IEnumerator OnCollisionEnter2D(Collision2D other)
		{
			if (_canCollide)
			{
				Vector2 reflectionDirection = Vector2.Reflect(_lastFrameVelocity, other.contacts[0].normal);

				// This call yield 'wierd' results, possible solution is to use an up vector for the pad and down for the bricks
				if (reflectionDirection == Vector2.zero)
				{
					reflectionDirection = ((Vector2)_lastFrameVelocity.normalized + Vector2.up).normalized;
				}

				rigidbody2D.AddForce(reflectionDirection * reflectionForce * rigidbody2D.mass, ForceMode2D.Impulse);

				if (other.gameObject.TryGetComponent(out BrickView brickView))
				{
					_canCollide = false;
					brickView.TryToDestroy();
					yield return null;
					_canCollide = true;
				}
			}
		}

		private void OnTriggerEnter2D(Collider2D other) =>
			_gameStateMachine.SwitchState(GameStateType.Gameover).Forget();
	}
}
