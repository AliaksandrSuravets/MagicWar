using System;
using UnityEngine;

namespace MagicWar
{
    public class Health : MonoBehaviour
    {
        #region Variables

        [Header("Settings")]
        [SerializeField] private int _startHp = 3;

        #endregion

        #region Properties

        public event Action HpLessZero;
        
        public int Hp { get; private set; }
        public bool IsDead { get; private set; }

        private void Start()
        {
            Hp = _startHp;
        }

        public void ApplyDamage(int value)
        {
            Hp -= value;
            CheckDead();
        }

        public void ApplyHeal(int value)
        {
            Hp += value;
        }

        public void CheckDead()
        {
            if (Hp > 0)
            {
                return;
            }
            HpLessZero?.Invoke();
            IsDead = true;
        }

        #endregion
    }
}