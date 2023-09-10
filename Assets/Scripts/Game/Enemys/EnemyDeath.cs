using MagicWar.Game.Player;
using UnityEngine;

namespace MagicWar.Game.Enemys
{
    public class EnemyDeath : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private Health _health;
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private Collider2D _collider2D;

        #endregion

        #region Unity lifecycle

        public void Start()
        {
            _health.HpLessZero += HpLessZero;
        }

        private void OnDestroy()
        {
            _health.HpLessZero -= HpLessZero;
        }

        #endregion

        #region Private methods

        private void HpLessZero()
        {
            _animation.PlayDeath();
            _collider2D.enabled = false;
        }

        #endregion
    }
}