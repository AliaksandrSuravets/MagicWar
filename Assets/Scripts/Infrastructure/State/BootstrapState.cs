using MagicWar.Service.Coroutine;
using MagicWar.Service.Gameplay;
using MagicWar.Service.Input;
using MagicWar.Service.LevelManagement;
using MagicWar.Service.Mission;
using MagicWar.Service.SceneLoading;

namespace MagicWar.Infrastructure
{
    public class BootstrapState : AppState
    {
        #region Setup/Teardown

        public BootstrapState(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region Public methods

        public override void Enter()
        {
            SceneLoadingService sceneLoadingService = new SceneLoadingService();
            ServiceLocator.Register(sceneLoadingService);
            MissionGameService missionGameService = new MissionGameService();
            ServiceLocator.Register(missionGameService);
            LevelManagementService levelManagementService = new LevelManagementService(sceneLoadingService);
            ServiceLocator.Register(levelManagementService);
            ServiceLocator.RegisterMonoBeh<CoroutineRunner>();
            ServiceLocator.Register(new GameplayService(missionGameService, levelManagementService, StateMachine));

#if UNITY_STANDALONE
            ServiceLocator.Register<IInputService>(new StandaloneInputService());
#elif UNITY_ANDROID || UNITY_IOS
            ServiceLocator.Register<IInputService>(new MobileInputService());
#endif

            StateMachine.Enter<MenuState>();
        }

        public override void Exit() { }

        #endregion
    }
}