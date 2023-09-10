using UnityEngine;

namespace MagicWar.Game.Potions
{
    public class HealPotion : Potion
    {
        #region Variables

        [SerializeField] private int _hpRestore;

        #endregion

        #region Unity lifecycle

        protected override void OnCollisionEnter2D(Collision2D other)
        {
            Health health = other.gameObject.GetComponent<Health>();
            health.ApplyHeal(_hpRestore);
            Destroy(gameObject);
        }

        #endregion
    }
}