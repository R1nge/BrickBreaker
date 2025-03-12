using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Brick;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
	public class BrickFactory
	{
		private readonly ConfigProvider _configProvider;
		private readonly IObjectResolver _objectResolver;

		private BrickFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
		{
			_objectResolver = objectResolver;
			_configProvider = configProvider;
		}

		public BrickView Create(Vector2 position, Transform parent)
		{
			var brick = _objectResolver.Instantiate(_configProvider.GameConfig.BrickView);
			brick.transform.SetParent(parent);
			brick.transform.position = position;
			return brick;
		}
	}
}
