﻿using System;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.Input;
using _Assets.Scripts.Services.SpawnPoints;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine
{
	public class MainMenuStatesFactory
	{
		private readonly BallFactory _ballFactory;
		private readonly BrickFactory _brickFactory;
		private readonly PadFactory _padFactory;
		private readonly PlayerInput _playerInput;
		private readonly SpawnPointService _spawnPointService;
		private readonly UIStateMachine _uiStateMachine;

		private MainMenuStatesFactory(UIStateMachine uiStateMachine, BallFactory ballFactory, BrickFactory brickFactory,
			PadFactory padFactory, SpawnPointService spawnPointService, PlayerInput playerInput)
		{
			_uiStateMachine = uiStateMachine;
			_ballFactory = ballFactory;
			_brickFactory = brickFactory;
			_padFactory = padFactory;
			_spawnPointService = spawnPointService;
			_playerInput = playerInput;
		}

		public IAsyncState CreateAsyncState(GameStateType gameStateType, GameStateMachine gameStateMachine)
		{
			switch (gameStateType)
			{
				case GameStateType.Init:
					return new InitState(gameStateMachine, _uiStateMachine);
				case GameStateType.Game:
					return new GameState(gameStateMachine, _uiStateMachine, _ballFactory, _brickFactory, _padFactory,
						_spawnPointService, _playerInput);
				default:
					throw new ArgumentOutOfRangeException(nameof(gameStateType), gameStateType, null);
			}
		}
	}
}
