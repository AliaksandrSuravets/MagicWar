using MagicWar.Game;
using MagicWar.Game.Player;
using MagicWar.Game.Potions;
using UnityEngine;

namespace MagicWar
{
    public class ManaPotion : Potion
    {
            #region Variables

            [SerializeField] private int _plusMana;

            #endregion

            #region Unity lifecycle

            public override void Aplly(Collision2D other)
            {
                if (other.gameObject.TryGetComponent(out PlayerAttack Mana))
                {
                    Mana.ChangeMana(_plusMana);
                }
                Destroy(gameObject);
            }

            #endregion
        }
}
