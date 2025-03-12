using _Assets.Scripts.Services.Brick;
using _Assets.Scripts.Services.Score;
using _Assets.Scripts.Services.UIs.StateMachine;
using Cysharp.Threading.Tasks;

namespace _Assets.Scripts.Services.StateMachine.States
{
	public class WinState : IAsyncState
	{
		private readonly BrickAmountChecker _brickAmountChecker;
		private readonly ScoreHolder _scoreHolder;
		private readonly UIStateMachine _uiStateMachine;

		public WinState(UIStateMachine uiStateMachine, ScoreHolder scoreHolder, BrickAmountChecker brickAmountChecker)
		{
			_uiStateMachine = uiStateMachine;
			_scoreHolder = scoreHolder;
			_brickAmountChecker = brickAmountChecker;
		}

		public async UniTask Enter()
		{
			await _uiStateMachine.SwitchState(UIStateType.Win);
		}

		public async UniTask Exit()
		{
			_scoreHolder.ResetPoints();
			_brickAmountChecker.Reset();
		}
	}
}
