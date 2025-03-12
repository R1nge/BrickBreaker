using _Assets.Scripts.Services.Ball;
using _Assets.Scripts.Services.Brick;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.Input;
using _Assets.Scripts.Services.Score;
using _Assets.Scripts.Services.SpawnPoints;
using _Assets.Scripts.Services.UIs.StateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Assets.Scripts.Services.StateMachine.States
{
	public class GameState : IAsyncState
	{
		private readonly BallHolder _ballHolder;
		private readonly BrickGenerator _brickGenerator;
		private readonly PadFactory _padFactory;
		private readonly PlayerInput _playerInput;
		private readonly ScoreHolder _scoreHolder;
		private readonly SpawnPointService _spawnPointService;
		private readonly GameStateMachine _stateMachine;
		private readonly UIStateMachine _uiStateMachine;

		public GameState(GameStateMachine stateMachine, UIStateMachine uiStateMachine,
			BrickGenerator brickGenerator, PadFactory padFactory, SpawnPointService spawnPointService,
			PlayerInput playerInput, ScoreHolder scoreHolder, BallHolder ballHolder)
		{
			_uiStateMachine = uiStateMachine;
			_stateMachine = stateMachine;
			_brickGenerator = brickGenerator;
			_padFactory = padFactory;
			_spawnPointService = spawnPointService;
			_playerInput = playerInput;
			_scoreHolder = scoreHolder;
			_ballHolder = ballHolder;
		}

		public async UniTask Enter()
		{
			await _uiStateMachine.SwitchState(UIStateType.Game);
			_playerInput.Enable();
			Transform brickParent = _spawnPointService.GetSpawnPoint(SpawnPointService.SpawnPointType.Brick);
			_brickGenerator.Generate(brickParent, 5, 5);
			Transform padParent = _spawnPointService.GetSpawnPoint(SpawnPointService.SpawnPointType.Pad);
			_padFactory.Create(padParent.position, padParent.root);
		}

		public async UniTask Exit()
		{
			_ballHolder.DisablePhysics();
			_scoreHolder.ResetPoints();
			_playerInput.Disable();
		}
	}
}
