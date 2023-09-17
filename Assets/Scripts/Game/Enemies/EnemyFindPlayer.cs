using UnityEngine;

namespace MagicWar.Game.Enemies
{
    public class EnemyFindPlayer : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private Transform _playerTransform; //???

        #endregion

        #region Unity lifecycle

        private void Update()
        {
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