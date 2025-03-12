using UnityEngine;

namespace _Assets.Scripts.Services.Input
{
	public class PlayerInput
	{
		public bool Enabled { get; private set; }

		public float PositionXNormalized { get; private set; }

		public void Enable() => Enabled = true;

		public void Disable() => Enabled = false;

		public void SetPlayerPositionX(float positionX)
		{
			if (!Enabled)
			{
				Debug.LogWarning("Trying to set input when disabled");
				return;
			}

			PositionXNormalized = positionX;
		}
	}
}
