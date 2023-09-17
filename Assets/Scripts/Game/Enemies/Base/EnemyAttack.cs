using System.Collections;
using UnityEngine;

namespace MagicWar.Game.Enemies
{
    public class EnemyAttack : EnemyComponent
    {
        #region Variables

        [Header(nameof(EnemyAttack))]
        [SerializeField] private float _attackDelay = 3f;

        private IEnumerator _attackRoutine;
        private bool _canFire = true;
        private WaitForSeconds _wait;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _wait = new WaitForSeconds(_attackDelay);
        }

        private void OnDisable()
        {
            StopAttack();
        }

        #endregion

        #region Public methods

        public void StartAttack()
        {
            _attackRoutine = StartAttackInternal();
            StartCoroutine(_attackRoutine);
        }

        public void StopAttack()
        {
            if (_attackRoutine != null)
            {
                StopCoroutine(_attackRoutine);
                _attackRoutine = null;
            }
        }

        #endregion

        #region Protected methods

        protected virtual void OnPerformAttack() { }

        #endregion

        #region Private methods

        private IEnumerator ChangeCanFire()
        {
            _canFire = false;
            yield return _wait;
            _canFire = true;
        }

        private IEnumerator StartAttackInternal()
        {
            while (true)
            {
                if (_canFire)
                {
                    OnPerformAttack();
                    StartCoroutine(ChangeCanFire());
                }

                yield return _wait;
            }
        }

        #endregion
    }
}