using _Assets.Scripts.Services.Brick;
using _Assets.Scripts.Services.Score;
using _Assets.Scripts.Services.UIs.StateMachine;
using Cysharp.Threading.Tasks;

namespace _Assets.Scripts.Services.StateMachine.States
{
	public class GameOverState : IAsyncState
	{
		private readonly BrickHolder _brickHolder;
		private readonly ScoreHolder _scoreHolder;
		private readonly UIStateMachine _uiStateMachine;

		public GameOverState(UIStateMachine uiStateMachine, ScoreHolder scoreHolder,
			BrickHolder brickHolder)
		{
			_uiStateMachine = uiStateMachine;
			_scoreHolder = scoreHolder;
			_brickHolder = brickHolder;
		}

		public async UniTask Enter() => await _uiStateMachine.SwitchState(UIStateType.Gameover);

		//TODO: save score
		public async UniTask Exit()
		{
			//TODO: clear map, player, score...
			_brickHolder.Reset();
			_scoreHolder.ResetPoints();
		}
	}
}
