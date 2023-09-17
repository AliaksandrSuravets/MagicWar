using UnityEngine;

namespace MagicWar.Game.Potions
{
    public class HealPotion : Potion
    {
        #region Variables

        [SerializeField] private int _hpRestore;

        #endregion

        #region Unity lifecycle

        public override void Aplly(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Health healthp))
            {
                healthp.Change(_hpRestore);
            }
            Destroy(gameObject);
        }

        #endregion
    }
}