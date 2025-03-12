using _Assets.Scripts.Services.Brick;
using _Assets.Scripts.Services.Score;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Brick
{
	public class BrickView : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer spriteRenderer;
		[SerializeField] private Color32[] colors;
		[SerializeField] private int hitsToDestroy;
		[SerializeField] private int points;
		[SerializeField] private AudioSource audioSource;
		[Inject] private BrickHolder _brickHolder;
		private int _currentHits;
		[Inject] private ScoreHolder _scoreHolder;

		private void Awake() => ApplyRandomColorPreset();

		public void TryToDestroy()
		{
			_currentHits++;
			if (_currentHits >= hitsToDestroy)
			{
				_scoreHolder.AddPoints(points);
				_brickHolder.Remove(gameObject);
				Instantiate(audioSource, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
		}

		private void ApplyRandomColorPreset() => spriteRenderer.color = colors[Random.Range(0, colors.Length)];
	}
}
