using System;
using _Assets.Scripts.Services.Ball;
using _Assets.Scripts.Services.Brick;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.Input;
using _Assets.Scripts.Services.Score;
using _Assets.Scripts.Services.SpawnPoints;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine
{
	public class MainMenuStatesFactory
	{
		private readonly BallFactory _ballFactory;
		private readonly BallHolder _ballHolder;
		private readonly BrickGenerator _brickGenerator;
		private readonly BrickHolder _brickHolder;
		private readonly PadFactory _padFactory;
		private readonly PlayerInput _playerInput;
		private readonly ScoreHolder _scoreHolder;
		private readonly SpawnPointService _spawnPointService;
		private readonly UIStateMachine _uiStateMachine;

		private MainMenuStatesFactory(UIStateMachine uiStateMachine, BallFactory ballFactory,
			BrickGenerator brickGenerator,
			PadFactory padFactory, SpawnPointService spawnPointService, PlayerInput playerInput,
			ScoreHolder scoreHolder, BrickHolder brickHolder, BallHolder ballHolder)
		{
			_uiStateMachine = uiStateMachine;
			_ballFactory = ballFactory;
			_brickGenerator = brickGenerator;
			_padFactory = padFactory;
			_spawnPointService = spawnPointService;
			_playerInput = playerInput;
			_scoreHolder = scoreHolder;
			_brickHolder = brickHolder;
			_ballHolder = ballHolder;
		}

		public IAsyncState CreateAsyncState(GameStateType gameStateType, GameStateMachine gameStateMachine)
		{
			switch (gameStateType)
			{
				case GameStateType.Init:
					return new InitState(gameStateMachine, _uiStateMachine);
				case GameStateType.Game:
					return new GameState(gameStateMachine, _uiStateMachine, _brickGenerator, _padFactory,
						_spawnPointService, _playerInput, _scoreHolder, _ballHolder);
				case GameStateType.Gameover:
					return new GameOverState(_uiStateMachine, _scoreHolder, _brickHolder, _ballHolder);
				case GameStateType.Win:
					return new WinState(_uiStateMachine, _scoreHolder, _brickHolder);
				default:
					throw new ArgumentOutOfRangeException(nameof(gameStateType), gameStateType, null);
			}
		}
	}
}
