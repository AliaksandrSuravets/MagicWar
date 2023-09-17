using System;
using UnityEngine;

namespace MagicWar.Game.Enemies
{
    public class EnemyPatrol : EnemyComponent
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyMovement _enemyMovement;
        [Header("Patrol")]
        [SerializeField] private Transform[] _wayPositions;
        private int _currentWayIndex;
        private bool _isNeedPatrol;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _isNeedPatrol = true;
            if (_wayPositions == null)
            {
                return;
            }

            _currentWayIndex = 0;
        }

        private void Update()
        {
            Patrol();
        }

        private void OnEnable()
        {
            _triggerObserver.OnEnter += OnEnter;
            _triggerObserver.OnExit += OnExit;
        }

        private void OnDisable()
        {
            _triggerObserver.OnEnter -= OnEnter;
            _triggerObserver.OnExit -= OnExit;
        }

        #endregion

        #region Private methods

        private void OnEnter(Collider2D other)
        {
            _isNeedPatrol = false;
        }

        private void OnExit(Collider2D other)
        {
            _isNeedPatrol = true;
        }

        private void Patrol()
        {
            if (!_isNeedPatrol)
            {
                return;
            }

            if (Vector2.Distance(transform.position, _wayPositions[_currentWayIndex].position) < 0.2f)
            {
                _currentWayIndex++;
                if (_currentWayIndex > _wayPositions.Length - 1)
                {
                    _currentWayIndex = 0;
                }
            }

            _enemyMovement.SetTarget(_wayPositions[_currentWayIndex]);
        }

        #endregion
    }
}