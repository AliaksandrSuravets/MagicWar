using MagicWar.Infrastructure;
using MagicWar.Service.LevelManagement;
using MagicWar.Service.Mission;
using UnityEngine;

namespace MagicWar.Service.Gameplay
{
    public class GameplayService : IService
    {
        #region Variables

        private readonly LevelManagementService _levelManagementService;
        private readonly StateMachine _stateMachine;
        private readonly MissionGameService _missionGameService;

        #endregion

        #region Setup/Teardown

        public GameplayService(MissionGameService missionGameService, LevelManagementService levelManagementService,
            StateMachine stateMachine)
        {
            _missionGameService = missionGameService;
            _levelManagementService = levelManagementService;
            _stateMachine = stateMachine;
        }

        #endregion

        #region Public methods

        public void Dispose()
        {
            _missionGameService.OnCompleted -= OnMissionCompleted;
        }

        public void Initialize()
        {
            _missionGameService.OnCompleted += OnMissionCompleted;
        }

        private void OnMissionCompleted()
        {
            _levelManagementService.IncrementLevel();

            if (_levelManagementService.IsCurrentLevelExists())
            {
                _stateMachine.Enter<GameState>();
            }
            else
            {
                _stateMachine.Enter<Win>();
            }
        }

        #endregion
    }
}