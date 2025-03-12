using UnityEngine;

namespace _Assets.Scripts.Configs
{
	[CreateAssetMenu(fileName = "UI Config", menuName = "Configs/UI")]
	public class UIConfig : ScriptableObject
	{
		[SerializeField] private GameObject loadingUI;
		[SerializeField] private GameObject gameUI;
		[SerializeField] private GameObject gameoverUI;
		[SerializeField] private GameObject winUI;
		public GameObject LoadingUI => loadingUI;
		public GameObject GameUI => gameUI;
		public GameObject GameoverUI => gameoverUI;
		public GameObject WinUI => winUI;
	}
}
