using MagicWar.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace MagicWar.Ui
{
    public class MenuScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Button _playButton;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        #endregion

        #region Private methods

        private void OnPlayButtonClicked()
        {
            ServiceLocator.Instance.Get<StateMachine>().Enter<GameState>();
        }

        #endregion
    }
}