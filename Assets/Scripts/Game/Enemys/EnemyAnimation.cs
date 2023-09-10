using UnityEngine;

namespace MagicWar.Game.Enemys
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        private static readonly int Dead = Animator.StringToHash("Dead");

        [SerializeField] private Animator _animator;

        #endregion

        #region Public methods

        public void PlayDeath()
        {
            _animator.SetTrigger(Dead);
        }

        #endregion
    }
}