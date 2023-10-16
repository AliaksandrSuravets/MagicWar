using MagicWar.Service.SceneLoading;

namespace MagicWar.Infrastructure
{
    public class Win: AppState
    {
        #region Setup/Teardown

        public Win(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region Public methods

        public override void Enter()
        {
            ServiceLocator.Get<SceneLoadingService>().LoadScene(Scene.Win);
        }

        public override void Exit() { }

        #endregion
    }
}
