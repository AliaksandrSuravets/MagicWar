using System;
using UnityEngine;

namespace MagicWar.Game.Enemies
{
    public class EnemyDeath : EnemyComponent
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private Health _health;
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private Collider2D _collider2D;

        [SerializeField] private EnemyComponent[] _enemyComponents;
        
        public bool IsDead { get; private set; }
            
        #endregion

        #region Events

        public event Action OnHappened;

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

            foreach (EnemyComponent enemyComponent in _enemyComponents)
            {
                enemyComponent.enabled = false;
            }
            
            IsDead = true;
            _collider2D.enabled = false;
            _animation.PlayDeath();
            OnHappened?.Invoke();
        }

        #endregion
    }
}