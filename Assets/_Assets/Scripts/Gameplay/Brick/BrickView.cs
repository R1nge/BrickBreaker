using _Assets.Scripts.Gameplay.Ball;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Brick
{
	public class BrickView : MonoBehaviour
	{
		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.TryGetComponent(out BallView ballView))
			{
				Destroy();
			}
		}

		private void Destroy()
		{
			Destroy(gameObject);
		}
	}
}
