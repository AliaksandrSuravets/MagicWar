using UnityEngine;

namespace MagicWar.Service.Mission
{
    public class MissionHolder : MonoBehaviour
    {
        [SerializeField] private MissionCondition _missionCondition;
        
        public MissionCondition MissionCondition => _missionCondition;
    }
}