using System;
using UnityEngine;

namespace MagicWar.Game
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerObserver : MonoBehaviour
    {
        #region Events

        public event Action<Collider2D> OnEnter;
        public event Action<Collider2D> OnExit;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(Tag.Player))
            {
                return;
            }

            OnEnter?.Invoke(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(Tag.Player))
            {
                return;
            }

            OnExit?.Invoke(other);
        }

        #endregion
    }
}