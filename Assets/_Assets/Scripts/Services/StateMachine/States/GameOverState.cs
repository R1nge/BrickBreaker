using _Assets.Scripts.Services.Brick;
using _Assets.Scripts.Services.Score;
using _Assets.Scripts.Services.UIs.StateMachine;
using Cysharp.Threading.Tasks;

namespace _Assets.Scripts.Services.StateMachine.States
{
	public class GameOverState : IAsyncState
	{
		private readonly BrickAmountChecker _brickAmountChecker;
		private readonly ScoreHolder _scoreHolder;
		private readonly UIStateMachine _uiStateMachine;

		public GameOverState(UIStateMachine uiStateMachine, ScoreHolder scoreHolder,
			BrickAmountChecker brickAmountChecker)
		{
			_uiStateMachine = uiStateMachine;
			_scoreHolder = scoreHolder;
			_brickAmountChecker = brickAmountChecker;
		}

		public async UniTask Enter() => await _uiStateMachine.SwitchState(UIStateType.Gameover);

		//TODO: save score
		public async UniTask Exit()
		{
			//TODO: clear map, player, score...
			_brickAmountChecker.Reset();
			_scoreHolder.ResetPoints();
		}
	}
}
