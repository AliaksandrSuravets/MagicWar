using System;
using Pathfinding;
using Unity.Mathematics;
using UnityEngine;

namespace MagicWar.Game.Enemies
{
    public class EnemyMovementAgro : EnemyComponent
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyIdle _idle;

        [SerializeField] private AIDestinationSetter _aiDestinationSetter;
        [SerializeField] private AIPath _aiPath;
        
        

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            _triggerObserver.OnEnter += OnObserverEnter;
            _triggerObserver.OnExit += OnObserverExit;
        }

        private void OnDisable()
        {
            _triggerObserver.OnEnter -= OnObserverEnter;
            _triggerObserver.OnExit -= OnObserverExit;
        }

        #endregion

        #region Private methods

        private void OnObserverEnter(Collider2D other)
        {
            _aiDestinationSetter.enabled = true;
            _aiPath.enabled = true;
            SetTarget(other.transform);
        }

        private void OnObserverExit(Collider2D other)
        {
            _aiDestinationSetter.enabled = false;
            _aiPath.enabled = false;
            SetTarget(null);
        }

        private void SetTarget(Transform otherTransform)
        {
            if (_enemyMovement != null)
            {
                _enemyMovement.SetTarget(otherTransform);
            }

            if (_idle != null)
            {
                if (otherTransform == null)
                {
                    _idle.Activate();
                }
                else
                {
                    _idle.Deactivate();
                }
            }
        }

        #endregion
    }
}