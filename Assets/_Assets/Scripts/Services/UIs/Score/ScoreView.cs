using _Assets.Scripts.Services.Score;
using TMPro;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs.Score
{
	public class ScoreView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI scoreText;
		[Inject] private ScoreHolder _scoreHolder;

		private void Awake() => _scoreHolder.OnScoreChanged += UpdateScore;

		private void OnDestroy() => _scoreHolder.OnScoreChanged -= UpdateScore;

		private void UpdateScore(int score) => scoreText.text = score.ToString();
	}
}
