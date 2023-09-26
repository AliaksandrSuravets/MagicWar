using UnityEngine;

namespace MagicWar.Service
{
    public class GameService : MonoBehaviour
    {
        #region Public methods

        public void OnDied(Component sender, object data)
        {
            if (data is not GameObject)
            {
                return;
            }

            GameObject gameObjectData = (GameObject) data;

            if (gameObjectData.CompareTag("Boss"))
            {
                LevelService.NextScene();
            }
            else
            {
                Debug.Log("Enemy died");
            }
        }

        public void OnTeleport(Component sender, object data)
        {
            LevelService.NextScene();
        }

        #endregion
    }
}