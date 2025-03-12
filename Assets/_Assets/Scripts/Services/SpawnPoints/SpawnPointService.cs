using System;
using UnityEngine;

namespace _Assets.Scripts.Services.SpawnPoints
{
	public class SpawnPointService
	{
		public enum SpawnPointType : byte
		{
			Ball = 0,
			Brick = 1,
			Pad = 2
		}

		private Transform _ballSpawnPoint;
		private Transform _brickSpawnPoint;
		private Transform _padSpawnPoint;

		public void SetSpawnPoint(SpawnPointType spawnPointType, Transform transform)
		{
			switch (spawnPointType)
			{
				case SpawnPointType.Ball:
					_ballSpawnPoint = transform;
					break;
				case SpawnPointType.Brick:
					_brickSpawnPoint = transform;
					break;
				case SpawnPointType.Pad:
					_padSpawnPoint = transform;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(spawnPointType), spawnPointType, null);
			}
		}

		public Transform GetSpawnPoint(SpawnPointType spawnPointType)
		{
			switch (spawnPointType)
			{
				case SpawnPointType.Ball:
					return _ballSpawnPoint;
				case SpawnPointType.Brick:
					return _brickSpawnPoint;
				case SpawnPointType.Pad:
					return _padSpawnPoint;
				default:
					throw new ArgumentOutOfRangeException(nameof(spawnPointType), spawnPointType, null);
			}
		}
	}
}
