using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.SpawnPoints
{
	public class SpawnPointSetter : MonoBehaviour
	{
		[SerializeField] private SpawnPointService.SpawnPointType spawnPointType;
		[Inject] private SpawnPointService _spawnPointService;

		private void Awake()
		{
			_spawnPointService.SetSpawnPoint(spawnPointType, transform);
		}
	}
}
