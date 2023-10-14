using MagicWar.Infrastructure;
using MagicWar.Service.SceneLoading;
using UnityEngine;

namespace MagicWar.Service.LevelManagement
{
    public class LevelManagementService : IService
    {
        #region Variables

        private const string ConfigPath = "Configs/LevelManagementServiceConfig";

        private readonly SceneLoadingService _sceneLoadingService;

        private LevelManagementServiceConfig _config;
        private int _currentSceneIndex;
        private bool _isConfigLoaded;

        #endregion

        #region Setup/Teardown

        public LevelManagementService(SceneLoadingService sceneLoadingService)
        {
            _sceneLoadingService = sceneLoadingService;
        }

        #endregion

        #region Public methods

        public void IncrementLevel()
        {
            _currentSceneIndex++;
        }

        public void Initialize()
        {
            LoadConfig();
        }

        public bool IsCurrentLevelExists()
        {
            return _config.SceneNames.Length > _currentSceneIndex;
        }

        public void LoadCurrentLevel()
        {
            _sceneLoadingService.LoadScene(_config.SceneNames[_currentSceneIndex]);
        }

        #endregion

        #region Private methods

        private void LoadConfig()
        {
            if (_isConfigLoaded)
            {
                return;
            }

            _config = Resources.Load<LevelManagementServiceConfig>(ConfigPath);
            _isConfigLoaded = true;
        }

        #endregion
    }
}