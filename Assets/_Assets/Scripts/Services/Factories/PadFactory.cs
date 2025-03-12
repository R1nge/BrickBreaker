using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Pad;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
	public class PadFactory
	{
		private readonly ConfigProvider _configProvider;
		private readonly IObjectResolver _objectResolver;

		private PadFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
		{
			_objectResolver = objectResolver;
			_configProvider = configProvider;
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
