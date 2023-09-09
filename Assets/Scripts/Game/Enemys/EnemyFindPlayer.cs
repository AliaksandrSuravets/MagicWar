using MagicWar.Game.Player;
using UnityEngine;

namespace MagicWar.Game.Enemys
{
    public class EnemyFindPlayer : MonoBehaviour
    {
        #region Unity lifecycle
        [Header("Components")]
        [SerializeField] private Transform _playerTransform; //???
        [SerializeField] private Health _health;
        
        private void Update()
        {
            if (_health.IsDead)
            {
                return;
            }
            Rotate();
        }

        #endregion

        #region Private methods

        private void Rotate()
        {
            Vector3 playerPosition = _playerTransform.position;
            playerPosition.z = 0;
            Vector3 direction = playerPosition - transform.position;
            transform.up = direction;
        }

        #endregion
    }
}