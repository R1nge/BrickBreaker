using UnityEngine;

namespace _Assets.Scripts.Gameplay.Ball
{
	public class BallView : MonoBehaviour
	{
		[SerializeField] private new Rigidbody2D rigidbody2D;
		[SerializeField] private float reflectionForce = 500f;
		[SerializeField] private float gravityForce;
		private Vector3 _lastFrameVelocity;

		private void Start()
		{
			rigidbody2D.AddForce(Vector2.down * reflectionForce * rigidbody2D.mass, ForceMode2D.Impulse);
		}

		private void Update() => _lastFrameVelocity = rigidbody2D.velocity;

		private void FixedUpdate() => rigidbody2D.AddForce(Vector2.down * (gravityForce * rigidbody2D.mass));

		private void OnCollisionEnter2D(Collision2D other)
		{
			var reflectionDirection = Vector2.Reflect(_lastFrameVelocity, other.contacts[0].normal);
			rigidbody2D.AddForce(reflectionDirection * reflectionForce * rigidbody2D.mass, ForceMode2D.Impulse);
		}
	}
}
