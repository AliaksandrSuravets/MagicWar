using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MagicWar.Game.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private Health _health;
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private PlayerAttack _playerAttack;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private Collider2D _collider2D;

        [Header("Settings")]
        [SerializeField] private float _timeForRestartLevel;

        #endregion

        #region Events

        public event Action OnHappened;

        #endregion

        #region Properties

        public bool GameOver { get; private set; }

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _health.OnChanged += OnHpChanged;
        }

        private void OnDisable()
        {
            _health.OnChanged -= OnHpChanged;
        }

        #endregion

        #region Private methods

        private void OnHpChanged(int currentHp)
        {
            
            if (currentHp > 0)
            {
                return;
            }

            GameOver = true;
            _playerAttack.enabled = false;
            _playerMovement.enabled = false;
            _collider2D.enabled = false;
            _animation.PlayDeath();
            StartCoroutine(RestartLevel());
            OnHappened?.Invoke();
        }

        private IEnumerator RestartLevel()
        {
            GameOver = true;
            yield return new WaitForSeconds(_timeForRestartLevel);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}