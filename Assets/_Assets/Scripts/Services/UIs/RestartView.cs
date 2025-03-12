using _Assets.Scripts.Services.StateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Assets.Scripts.Services.UIs
{
	public class RestartView : MonoBehaviour
	{
		[SerializeField] private Button restart;
		[Inject] private GameStateMachine _gameStateMachine;

		private void Awake() => restart.onClick.AddListener(Restart);

		private void OnDestroy() => restart.onClick.RemoveListener(Restart);

		private void Restart() => _gameStateMachine.SwitchState(GameStateType.Game).Forget();
	}
}
