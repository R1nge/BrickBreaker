using _Assets.Scripts.Gameplay.Ball;
using _Assets.Scripts.Services.Score;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Brick
{
	public class BrickView : MonoBehaviour
	{
		[SerializeField] private int hitsToDestroy;
		[SerializeField] private int points;
		private int _currentHits;
		[Inject] private ScoreHolder _scoreHolder;

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.TryGetComponent(out BallView ballView))
			{
				_currentHits++;
				if (_currentHits >= hitsToDestroy)
				{
					_scoreHolder.AddPoints(points);
					Destroy(gameObject);
				}
			}
		}
	}
}
