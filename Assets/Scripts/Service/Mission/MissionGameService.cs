using System;
using MagicWar.Infrastructure;
using Object = UnityEngine.Object;

namespace MagicWar.Service.Mission
{
    public class MissionGameService : IService
    {
        #region Variables

        private readonly MissionFactory _factory = new MissionFactory();

        private BaseMission _currentMission;

        #endregion

        #region Events

        public event Action OnCompleted;

        #endregion

        #region Public methods

        public void Dispose()
        {
            _currentMission.OnCompleted -= OnMissionCompleted;
            _currentMission.Dispose();
            _currentMission = null;
        }

        public void Initialize()
        {
            MissionHolder holder = Object.FindObjectOfType<MissionHolder>();
            _currentMission = _factory.Create(holder.MissionCondition);
            _currentMission.OnCompleted += OnMissionCompleted;
            _currentMission.Initialize();
        }

        #endregion

        #region Private methods

        private void OnMissionCompleted()
        {
            OnCompleted?.Invoke();
        }

        #endregion
    }
}