using UnityEngine;

namespace _Assets.Scripts.Configs
{
	public class ConfigProvider : MonoBehaviour
	{
		[SerializeField] private UIConfig uiConfig;
		[SerializeField] private GameConfig gameConfig;
		public UIConfig UIConfig => uiConfig;
		public GameConfig GameConfig => gameConfig;
	}
}
