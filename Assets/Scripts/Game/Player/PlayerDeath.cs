using System.Collections;
using System.Collections.Generic;
using MagicWar.Game.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MagicWar
{
    public class PlayerDeath : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private Health _health;
        [SerializeField] private PlayerAnimation _animation;
        [Header("Settings")]
        [SerializeField] private float _timeForRestartLevel;

        #endregion

        #region Properties

        public bool GameOver { get; private set; }

        #endregion

        #region Unity lifecycle

        public void Start()
        {
            _health.HpLessZero += HpLessZero;
        }

        private void OnDestroy()
        {
            _health.HpLessZero -= HpLessZero;
        }

        #endregion

        #region Private methods

        private void HpLessZero()
        {
            _animation.PlayDeath();
            StartCoroutine(RestartLevel());
        }

        private IEnumerator RestartLevel()
        {
            //to do special servi

            GameOver = true;
            yield return new WaitForSeconds(_timeForRestartLevel);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}