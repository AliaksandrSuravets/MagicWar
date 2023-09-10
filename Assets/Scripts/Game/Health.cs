using System;
using UnityEngine;

namespace MagicWar.Game
{
    public class Health : MonoBehaviour
    {
        #region Variables

        [Header("Settings")]
        [SerializeField] private int _startHp = 3;

        #endregion

        #region Events

        public event Action HpLessZero;

        #endregion

        #region Properties

        public int Hp { get; private set; }
        public bool IsDead { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            Hp = _startHp;
        }

        #endregion

        #region Public methods

        public void ApplyDamage(int value)
        {
            Hp -= value;
            CheckDead();
        }

        public void ApplyHeal(int value)
        {
            Hp += value;
        }

        #endregion

        #region Private methods

        private void CheckDead()
        {
            if (Hp == 0)
            {
                HpLessZero?.Invoke();
                IsDead = true;
            }
        }

        #endregion
    }
}