using _Assets.Scripts.Services.Factories;
using UnityEngine;

namespace _Assets.Scripts.Services.Brick
{
	public class BrickGenerator
	{
		private readonly BrickFactory _brickFactory;

		private BrickGenerator(BrickFactory brickFactory) => _brickFactory = brickFactory;

		public void Generate(Transform startPoint, int rows, int column)
		{
			const float BRICK_WIDTH = 1.35f;
			const float BRICK_HEIGHT = .75f;

			Vector3 startPointOffset = startPoint.position;

			for (int y = 0; y < column; y++)
			{
				for (int x = 0; x < rows; x++)
				{
					Vector3 offset = new(
						(x - (rows - 1) / 2f) * BRICK_WIDTH, // Center the bricks around the middle
						y * BRICK_HEIGHT,
						0
					);
					_brickFactory.Create(startPointOffset + offset, startPoint.root);
				}
			}
		}
	}
}
