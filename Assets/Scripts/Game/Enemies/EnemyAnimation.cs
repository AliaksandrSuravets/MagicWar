﻿using System;
using UnityEngine;
using UnityEngine.Scripting;

namespace MagicWar.Game.Enemies
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Dead = Animator.StringToHash("Dead");
        private static readonly int Speed = Animator.StringToHash("Speed");

        [SerializeField] private Animator _animator;

        #endregion

        #region Events

        public event Action OnMeleeAttackHit;

        #endregion

        #region Public methods

        public void PlayAttack()
        {
            _animator.SetTrigger(Attack);
        }

        public void PlayDeath()
        {
            _animator.SetTrigger(Dead);
        }

        public void SetSpeed(float value)
        {
            _animator.SetFloat(Speed, value);
        }

        #endregion

        #region Private methods

        [Preserve]
        private void MeleeAttackHit()
        {
            OnMeleeAttackHit?.Invoke();
        }

        #endregion
    }
}