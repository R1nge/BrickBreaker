using UnityEngine;

namespace _Assets.Scripts.Services.Ball
{
	public class BallHolder
	{
		private Rigidbody2D _ball;

		public void SetBall(Rigidbody2D ball) => _ball = ball;

		public void EnablePhysics()
		{
			if (_ball == null)
			{
				Debug.LogError("[BallHolder] Enable: ball is null");
				return;
			}

			_ball.isKinematic = false;
		}

		public void DisablePhysics()
		{
			if (_ball == null)
			{
				Debug.LogError("[BallHolder] Disable: ball is null");
				return;
			}

			_ball.isKinematic = true;
			_ball.velocity = Vector2.zero;
		}

		public void Destroy()
		{
			if (_ball == null)
			{
				Debug.LogError("[BallHolder] Destroy: ball is null");
				return;
			}

			Object.Destroy(_ball.gameObject);
		}
	}
}
