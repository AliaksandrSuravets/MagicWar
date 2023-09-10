using System;
using UnityEngine;

namespace MagicWar.Game.Potions
{
    public class Potion : MonoBehaviour
    {
        #region Unity lifecycle

        protected virtual void OnCollisionEnter2D(Collision2D other) { }

        #endregion
    }
}