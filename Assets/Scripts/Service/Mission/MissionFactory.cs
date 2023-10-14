using MagicWar.Service.Mission.KillAllEnemies;
using MagicWar.Service.Mission.KillSpecificEnemy;
using MagicWar.Service.Mission.ReachDestination;
using UnityEngine;

namespace MagicWar.Service.Mission
{
    public class MissionFactory
    {
        #region Public methods

        public BaseMission Create(MissionCondition condition)
        {
            if (condition is KillSpecificEnemyMissionCondition specificEnemyMissionCondition)
            {
                KillSpecificEnemyMission mission = new KillSpecificEnemyMission();
                mission.SetCondition(specificEnemyMissionCondition);
                return mission;
            }

            if (condition is ReachDestinationMissionCondition reachDestinationMissionCondition)
            {
                ReachDestinationMission mission = new ReachDestinationMission();
                mission.SetCondition(reachDestinationMissionCondition);
                return mission;
            }
            
            if (condition is KillAllEnemiesMissionCondition killAllEnemiesMissionCondition)
            {
                KillAllEnemiesMission mission = new KillAllEnemiesMission();
                mission.SetCondition(killAllEnemiesMissionCondition);
                return mission;
            }

            Debug.LogError($"No mission for conditions '{condition.GetType().Name}'");

            return null;
        }

        #endregion
    }
}