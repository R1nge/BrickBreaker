using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.UIs.StateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Assets.Scripts.Services.StateMachine.States
{
	public class GameState : IAsyncState
	{
		private readonly BallFactory _ballFactory;
		private readonly BrickFactory _brickFactory;
		private readonly PadFactory _padFactory;
		private readonly GameStateMachine _stateMachine;
		private readonly UIStateMachine _uiStateMachine;

		public GameState(GameStateMachine stateMachine, UIStateMachine uiStateMachine, BallFactory ballFactory,
			BrickFactory brickFactory, PadFactory padFactory)
		{
			_uiStateMachine = uiStateMachine;
			_stateMachine = stateMachine;
			_ballFactory = ballFactory;
			_brickFactory = brickFactory;
			_padFactory = padFactory;
		}

		public async UniTask Enter()
		{
			await _uiStateMachine.SwitchState(UIStateType.Game);
			_ballFactory.Create(Vector2.zero, null);
			_brickFactory.Create(Vector2.zero, null);
			_padFactory.Create(Vector2.zero, null);
		}

		public async UniTask Exit()
		{
		}
	}
}
