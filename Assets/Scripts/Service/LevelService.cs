using UnityEngine;
using UnityEngine.SceneManagement;

namespace MagicWar.Service
{
    public static class LevelService
    {
        #region Public methods

        public static void NextScene()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (SceneManager.sceneCount >= nextSceneIndex)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }

        #endregion
    }
}