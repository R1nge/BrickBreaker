using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Ball;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
	public class BallFactory
	{
		private readonly IObjectResolver _objectResolver;
		private readonly ConfigProvider _configProvider;

		private BallFactory(IObjectResolver objectResolver)
		{
			_objectResolver = objectResolver;
		}

		public BallView Create(Vector2 position, Transform parent)
		{
			var ball = _objectResolver.Instantiate(_configProvider.GameConfig.BallView);
			ball.transform.SetParent(parent);
			ball.transform.position = position;
			return ball;
		}
	}
}
