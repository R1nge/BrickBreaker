using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.SpawnPoints;
using _Assets.Scripts.Services.UIs.StateMachine;
using Cysharp.Threading.Tasks;

namespace _Assets.Scripts.Services.StateMachine.States
{
	public class GameState : IAsyncState
	{
		private readonly BallFactory _ballFactory;
		private readonly BrickFactory _brickFactory;
		private readonly PadFactory _padFactory;
		private readonly SpawnPointService _spawnPointService;
		private readonly GameStateMachine _stateMachine;
		private readonly UIStateMachine _uiStateMachine;

		public GameState(GameStateMachine stateMachine, UIStateMachine uiStateMachine, BallFactory ballFactory,
			BrickFactory brickFactory, PadFactory padFactory, SpawnPointService spawnPointService)
		{
			_uiStateMachine = uiStateMachine;
			_stateMachine = stateMachine;
			_ballFactory = ballFactory;
			_brickFactory = brickFactory;
			_padFactory = padFactory;
			_spawnPointService = spawnPointService;
		}

		public async UniTask Enter()
		{
			await _uiStateMachine.SwitchState(UIStateType.Game);
			await UniTask.DelayFrame(1);
			var ballParent = _spawnPointService.GetSpawnPoint(SpawnPointService.SpawnPointType.Ball);
			_ballFactory.Create(ballParent.position, ballParent.root);
			var brickParent = _spawnPointService.GetSpawnPoint(SpawnPointService.SpawnPointType.Brick);
			_brickFactory.Create(brickParent.position, brickParent.root);
			var padParent = _spawnPointService.GetSpawnPoint(SpawnPointService.SpawnPointType.Pad);
			_padFactory.Create(padParent.position, padParent.root);
		}

		public async UniTask Exit()
		{
		}
	}
}
