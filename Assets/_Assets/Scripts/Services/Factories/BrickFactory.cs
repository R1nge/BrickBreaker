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
		private readonly BrickAmountChecker _brickAmountChecker;
		private readonly ConfigProvider _configProvider;
		private readonly IObjectResolver _objectResolver;

		private BrickFactory(IObjectResolver objectResolver, ConfigProvider configProvider,
			BrickAmountChecker brickAmountChecker)
		{
			_objectResolver = objectResolver;
			_configProvider = configProvider;
			_brickAmountChecker = brickAmountChecker;
		}

		public BrickView Create(Vector2 position, Transform parent)
		{
			var brick = _objectResolver.Instantiate(_configProvider.GameConfig.BrickView);
			brick.transform.SetParent(parent, true);
			brick.transform.position = position;
			_brickAmountChecker.Add(1);
			return brick;
		}
	}
}
