using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs.StateMachine.States
{
	public class UIGameOverState : IAsyncState
	{
		private readonly MainMenuUIFactory _mainMenuUIFactory;
		private GameObject _ui;

		public UIGameOverState(MainMenuUIFactory mainMenuUIFactory) => _mainMenuUIFactory = mainMenuUIFactory;

		public async UniTask Enter() => _ui = _mainMenuUIFactory.CreateUI(UIStateType.Gameover);

		public async UniTask Exit() => Object.Destroy(_ui);
	}
}
