using MagicWar.Game.Spells;
using UnityEngine;

namespace MagicWar.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private Health _health;
        
        [Header("Settings")]
        [SerializeField] private Spell _spellPrefab;
        [SerializeField] private Transform _spellSpawnPositionTransform;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_health.IsDead)
            {
                return;
            }
            
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }
        }

        #endregion

        #region Private methods

        private void CreateSpell()
        {
            Instantiate(_spellPrefab, _spellSpawnPositionTransform.position, transform.rotation);
        }

        private void Fire()
        {
            _animation.PlayAttack();
            CreateSpell();
        }

        #endregion
    }
}