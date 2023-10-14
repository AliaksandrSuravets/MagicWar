using MagicWar.Game.Enemies;
using UnityEngine;

namespace MagicWar.Service.Mission.KillSpecificEnemy
{
    public class KillSpecificEnemyMissionCondition : MissionCondition
    {
        #region Variables

        [SerializeField] private EnemyDeath _enemyDeath;

        #endregion

        #region Properties

        public EnemyDeath EnemyDeath => _enemyDeath;

        #endregion
    }
}