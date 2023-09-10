using System;
using System.Collections;
using MagicWar.Game.Player;
using MagicWar.Game.Spells;
using UnityEngine;

namespace MagicWar.Game.Enemys
{
    public class EnemySpellAttack : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private Health _health;
        [Header("Settings")]
        [SerializeField] private Spell _spellPrefab;
        [SerializeField] private float _timeStartUseSpell;
        [SerializeField] private float _cooldown;

        private PlayerDeath _playerDeath; //todo

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _playerDeath = FindObjectOfType<PlayerDeath>();

            StartCoroutine(StartFire());
        }

        #endregion

        #region Private methods

        private void CreateSpell()
        {
            Instantiate(_spellPrefab, transform.position, transform.rotation);
        }

        private void Fire()
        {
            CreateSpell();
        }

        private IEnumerator StartFire()
        {
            yield return _timeStartUseSpell;

            while (!_health.IsDead && !_playerDeath.GameOver)
            {
                Fire();
                yield return new WaitForSeconds(_cooldown);
            }
        }

        #endregion
    }
}