using System;
using UnityEngine;

namespace MagicWar.Game.Potions
{
    public abstract class Potion : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnCollisionEnter2D(Collision2D other)
        {
            Aplly(other);
        }

        public virtual void Aplly(Collision2D other) { }

        #endregion
    }
}