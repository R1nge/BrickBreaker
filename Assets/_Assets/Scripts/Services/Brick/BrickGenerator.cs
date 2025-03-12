using _Assets.Scripts.Services.Factories;
using UnityEngine;

namespace _Assets.Scripts.Services.Brick
{
	public class BrickGenerator
	{
		private readonly BrickFactory _brickFactory;

		private BrickGenerator(BrickFactory brickFactory)
		{
			_brickFactory = brickFactory;
		}

		public void Generate(Transform startPoint, int rows, int column)
		{
			float screenHeight = 2f * Camera.main.orthographicSize;
			float screenWidth = screenHeight * Camera.main.aspect;

			Vector3 startPointOffset = startPoint.position;
			startPointOffset.x -= screenWidth / 2f; // Center

			for (int y = 0; y < column; y++)
			{
				for (int x = 0; x < rows; x++)
				{
					const int BRICK_WIDTH = 100;
					Vector3 offset = new(
						(x - (rows / 2f)) * BRICK_WIDTH, // Center the bricks around the middle
						y * 100,
						0
					);
					_brickFactory.Create(startPointOffset + offset, startPoint.root);
				}
			}
		}
	}
}
