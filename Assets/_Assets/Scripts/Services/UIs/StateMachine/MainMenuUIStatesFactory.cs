using System;
using _Assets.Scripts.Services.UIs.StateMachine.States;

namespace _Assets.Scripts.Services.UIs.StateMachine
{
	public class MainMenuUIStatesFactory
	{
		private readonly MainMenuUIFactory _mainMenuUIFactory;

		private MainMenuUIStatesFactory(MainMenuUIFactory mainMenuUIFactory) => _mainMenuUIFactory = mainMenuUIFactory;

		public IAsyncState CreateState(UIStateType uiStateType, UIStateMachine uiStateMachine)
		{
			switch (uiStateType)
			{
				case UIStateType.Loading:
					return new UILoadingState(_mainMenuUIFactory);
				case UIStateType.Game:
					return new UIGameState(_mainMenuUIFactory);
				case UIStateType.Gameover:
					return new UIGameOverState(_mainMenuUIFactory);
				case UIStateType.Win:
					return new UIWinState(_mainMenuUIFactory);
				default:
					throw new ArgumentOutOfRangeException(nameof(uiStateType), uiStateType, null);
			}
		}
	}
}
