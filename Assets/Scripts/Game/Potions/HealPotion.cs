using UnityEngine;

namespace MagicWar.Game.Potions
{
    public class HealPotion : Potion
    {
        [SerializeField] private int _hpRestore;
        
        protected override void OnCollisionEnter2D(Collision2D other)
        {
            Health health = other.gameObject.GetComponent<Health>();
            health.ApplyHeal(_hpRestore);
            Destroy(gameObject);
        }
    }
}