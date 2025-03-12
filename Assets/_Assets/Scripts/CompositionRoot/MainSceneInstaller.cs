using _Assets.Scripts.Services.Brick;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.Input;
using _Assets.Scripts.Services.Score;
using _Assets.Scripts.Services.SpawnPoints;
using _Assets.Scripts.Services.StateMachine;
using _Assets.Scripts.Services.StateMachine.StatesCreators;
using _Assets.Scripts.Services.UIs;
using _Assets.Scripts.Services.UIs.StateMachine;
using _Assets.Scripts.Services.UIs.StatesCreators;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
	public class MainSceneInstaller : LifetimeScope
	{
		protected override void Configure(IContainerBuilder builder)
		{
			builder.Register<BrickGenerator>(Lifetime.Singleton);
			builder.Register<ScoreHolder>(Lifetime.Singleton);
			builder.Register<SpawnPointService>(Lifetime.Singleton);

			builder.Register<PlayerInput>(Lifetime.Singleton);

			builder.Register<BallFactory>(Lifetime.Singleton);
			builder.Register<BrickFactory>(Lifetime.Singleton);
			builder.Register<PadFactory>(Lifetime.Singleton);

			builder.Register<MainMenuUIStatesFactory>(Lifetime.Singleton);
			builder.Register<MainMenuUIFactory>(Lifetime.Singleton);
			builder.Register<MainMenuStatesFactory>(Lifetime.Singleton);

			builder.Register<UIMainSceneStateCreator>(Lifetime.Singleton);
			builder.Register<MainSceneStateCreator>(Lifetime.Singleton);
		}
	}
}
