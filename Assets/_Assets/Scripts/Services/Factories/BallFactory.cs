using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Ball;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
	public class BallFactory
	{
		private readonly ConfigProvider _configProvider;
		private readonly IObjectResolver _objectResolver;

		private BallFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
		{
			_objectResolver = objectResolver;
			_configProvider = configProvider;
		}

		public BallView Create(Vector2 position, Transform parent)
		{
			BallView ball = _objectResolver.Instantiate(_configProvider.GameConfig.BallView);
			ball.transform.SetParent(parent, true);
			ball.transform.position = position;
			return ball;
		}
	}
}
