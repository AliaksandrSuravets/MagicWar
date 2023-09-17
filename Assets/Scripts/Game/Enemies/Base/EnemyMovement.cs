using UnityEngine;

namespace MagicWar.Game.Enemies
{
    public abstract class EnemyMovement : EnemyComponent
    {
        #region Public methods

        public abstract void SetTarget(Transform target);

        #endregion
    }
}