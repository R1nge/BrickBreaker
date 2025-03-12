using _Assets.Scripts.Services.Brick;
using _Assets.Scripts.Services.Score;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Assets.Scripts.Gameplay.Brick
{
	public class BrickView : MonoBehaviour
	{
		[SerializeField] private Image image;
		[SerializeField] private Color32[] colors;
		[SerializeField] private int hitsToDestroy;
		[SerializeField] private int points;
		[SerializeField] private AudioSource audioSource;
		[Inject] private BrickAmountChecker _brickAmountChecker;
		private int _currentHits;
		[Inject] private ScoreHolder _scoreHolder;

		private void Awake() => ApplyRandomColorPreset();

		public void TryToDestroy()
		{
			_currentHits++;
			if (_currentHits >= hitsToDestroy)
			{
				_scoreHolder.AddPoints(points);
				_brickAmountChecker.Remove(1);
				Instantiate(audioSource, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
		}

		private void ApplyRandomColorPreset() => image.color = colors[Random.Range(0, colors.Length)];
	}
}
