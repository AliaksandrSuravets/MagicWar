using UnityEngine;

namespace MagicWar.Game.Enemies
{
    public class EnemyComponent : MonoBehaviour
    {
        #region Public methods

        public void Activate()
        {
            enabled = true;
        }

        public void Deactivate()
        {
            enabled = false;
        }

        #endregion
    }
}