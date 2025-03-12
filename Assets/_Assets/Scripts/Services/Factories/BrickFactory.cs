using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Brick;
using _Assets.Scripts.Services.Brick;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
	public class BrickFactory
	{
		private readonly BrickHolder _brickHolder;
		private readonly ConfigProvider _configProvider;
		private readonly IObjectResolver _objectResolver;

		private BrickFactory(IObjectResolver objectResolver, ConfigProvider configProvider,
			BrickHolder brickHolder)
		{
			_objectResolver = objectResolver;
			_configProvider = configProvider;
			_brickHolder = brickHolder;
		}

		public BrickView Create(Vector3 position, Transform parent)
		{
			BrickView brick = _objectResolver.Instantiate(_configProvider.GameConfig.BrickView);
			brick.transform.position = position;
			_brickHolder.Add(brick.gameObject);
			return brick;
		}
	}
}
