using MagicWar.Service.SceneLoading;

namespace MagicWar.Infrastructure
{
    public class MenuState : AppState
    {
        #region Setup/Teardown

        public MenuState(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region Public methods

        public override void Enter()
        {
            ServiceLocator.Get<SceneLoadingService>().LoadScene(Scene.Menu);
        }

        public override void Exit() { }

        #endregion
    }
}