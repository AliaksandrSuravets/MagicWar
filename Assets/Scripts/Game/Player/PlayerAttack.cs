using System.Collections;
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
        [SerializeField] private float _cooldown = 2f;

        private bool _canFire = true;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_health.IsDead)
            {
                return;
            }

            if (Input.GetButtonDown("Fire1") && _canFire)
            {
                StartCoroutine(ChangeCanFire());
                Fire();
            }
        }

        #endregion

        #region Private methods

        private IEnumerator ChangeCanFire()
        {
            _canFire = false;
            yield return new WaitForSeconds(_cooldown);
            _canFire = true;
        }

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