using UnityEngine;

namespace MagicWar.Game.Barrel
{
    public class BoomBarrel : MonoBehaviour
    {
        #region Variables

        [Header("Explosive")]
        [SerializeField] private float _explosiveRadius = 2f;
        [SerializeField] private LayerMask _blockMask;
        [SerializeField] private int _damage = 1;

        #endregion

        #region Unity lifecycle

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _explosiveRadius);
        }

        #endregion

        #region Public methods

        public void OnDestroyedActions()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosiveRadius);

            foreach (Collider2D col in colliders)
            {
                if (col.TryGetComponent(out Health health))
                {
                    health.Change(-_damage);
                }
            }
        }

        #endregion
    }
}