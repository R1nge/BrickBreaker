namespace _Assets.Scripts.Services.Input
{
	public class PlayerInput
	{
		public bool Enabled { get; private set; }

		public void Enable() => Enabled = true;

		public void Disable() => Enabled = false;

		public float PositionX { get; private set; }

		public void SetPlayerPositionX(float positionX) => PositionX = positionX;
	}
}
