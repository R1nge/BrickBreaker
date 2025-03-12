using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Ball;
using _Assets.Scripts.Gameplay.Pad;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
	public class PadFactory
	{
		private readonly IObjectResolver _objectResolver;
		private readonly ConfigProvider _configProvider;

		private PadFactory(IObjectResolver objectResolver)
		{
			_objectResolver = objectResolver;
		}

		public PadView Create(Vector2 position, Transform parent)
		{
			var pad = _objectResolver.Instantiate(_configProvider.GameConfig.Pad);
			pad.transform.SetParent(parent);
			pad.transform.position = position;
			return pad;
		}
	}
}
