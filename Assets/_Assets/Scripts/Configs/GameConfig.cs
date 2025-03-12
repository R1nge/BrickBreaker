using _Assets.Scripts.Gameplay.Ball;
using _Assets.Scripts.Gameplay.Brick;
using _Assets.Scripts.Gameplay.Pad;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
	[CreateAssetMenu(fileName = "Game", menuName = "Configs/Game", order = 0)]
	public class GameConfig : ScriptableObject
	{
		[SerializeField] private PadView pad;
		[SerializeField] private BrickView brickView;
		[SerializeField] private BallView ballView;
		public PadView Pad => pad;
		public BrickView BrickView => brickView;
		public BallView BallView => ballView;
	}
}
