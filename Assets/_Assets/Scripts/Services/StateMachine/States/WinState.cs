using _Assets.Scripts.Services.Ball;
using _Assets.Scripts.Services.Brick;
using _Assets.Scripts.Services.Score;
using _Assets.Scripts.Services.UIs.StateMachine;
using Cysharp.Threading.Tasks;

namespace _Assets.Scripts.Services.StateMachine.States
{
	public class WinState : IAsyncState
	{
		private readonly BallHolder _ballHolder;
		private readonly BrickHolder _brickHolder;
		private readonly ScoreHolder _scoreHolder;
		private readonly UIStateMachine _uiStateMachine;

		public WinState(UIStateMachine uiStateMachine, ScoreHolder scoreHolder, BrickHolder brickHolder,
			BallHolder ballHolder)
		{
			_uiStateMachine = uiStateMachine;
			_scoreHolder = scoreHolder;
			_brickHolder = brickHolder;
			_ballHolder = ballHolder;
		}

		public async UniTask Enter() => await _uiStateMachine.SwitchState(UIStateType.Win);

		public async UniTask Exit()
		{
			_scoreHolder.ResetPoints();
			_brickHolder.Reset();
			_ballHolder.Destroy();
		}
	}
}
