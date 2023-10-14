using MagicWar.Infrastructure;
using UnityEngine.SceneManagement;

namespace MagicWar.Service.SceneLoading
{
    public class SceneLoadingService : IService
    {
        #region Public methods

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        #endregion
    }
}