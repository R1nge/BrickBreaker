using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs.StateMachine.States
{
	public class UIWinState : IAsyncState
	{
		private readonly MainMenuUIFactory _mainMenuUIFactory;
		private GameObject _ui;

		public UIWinState(MainMenuUIFactory mainMenuUIFactory) => _mainMenuUIFactory = mainMenuUIFactory;

		public async UniTask Enter() => _ui = _mainMenuUIFactory.CreateUI(UIStateType.Win);

		public async UniTask Exit() => Object.Destroy(_ui);
	}
}
