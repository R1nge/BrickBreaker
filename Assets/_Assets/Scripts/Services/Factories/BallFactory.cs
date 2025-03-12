using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Ball;
using _Assets.Scripts.Services.Ball;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
	public class BallFactory
	{
		private readonly BallHolder _ballHolder;
		private readonly ConfigProvider _configProvider;
		private readonly IObjectResolver _objectResolver;

		private BallFactory(IObjectResolver objectResolver, ConfigProvider configProvider, BallHolder ballHolder)
		{
			_objectResolver = objectResolver;
			_configProvider = configProvider;
			_ballHolder = ballHolder;
		}

		public BallView Create(Vector3 position, Transform parent)
		{
			BallView ball = _objectResolver.Instantiate(_configProvider.GameConfig.BallView);
			ball.transform.position = position;
			_ballHolder.SetBall(ball.GetComponent<Rigidbody2D>());
			return ball;
		}
	}
}
