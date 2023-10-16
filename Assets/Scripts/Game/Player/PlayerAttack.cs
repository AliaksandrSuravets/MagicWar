using System;
using System.Collections;
using Lean.Pool;
using MagicWar.Game.Spells;
using TMPro;
using UnityEngine;

namespace MagicWar.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [Header("Mana")]
        [SerializeField] private int _mana;

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
            if (!Input.GetButtonDown("Fire1") || !_canFire || _mana < 1)
            {
                return;
            }

            StartCoroutine(ChangeCanFire());
            Fire();
        }

        #endregion

        #region Public methods

        public void ChangeMana(int value)
        {
            _mana += value;
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
            LeanPool.Spawn(_spellPrefab, _spellSpawnPositionTransform.position, transform.rotation);
        }

        private void Fire()
        {
            _mana--;
            _animation.PlayAttack();
            CreateSpell();
        }

        #endregion
    }
}