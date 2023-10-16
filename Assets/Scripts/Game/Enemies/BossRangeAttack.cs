using MagicWar.Game.Spells;
using UnityEngine;


namespace MagicWar.Game.Enemies
{
    public class BossRangeAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(EnemyRangeAttack))]
        [SerializeField] private Spell _spellPrefab;
        [SerializeField] private Transform[] _spellSpawnPositionTransform;

        private Transform _playerTransform;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _playerTransform = GameObject.FindWithTag(Tag.Player).transform;
        }

        #endregion

        #region Protected methods

        protected override void OnPerformAttack()
        {
            base.OnPerformAttack();

            Vector3 direction = _playerTransform.position - transform.position;
            transform.up = direction;

            foreach (Transform spawnPos in _spellSpawnPositionTransform) 
            {
                Instantiate(_spellPrefab, spawnPos.position, transform.rotation);
            }
            
            Animation.PlayAttack();
        }

        #endregion
    }
}