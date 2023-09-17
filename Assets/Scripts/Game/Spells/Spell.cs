using System;
using MagicWar.Utility;
using UnityEngine;

namespace MagicWar.Game.Spells
{
    public class Spell : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifeTime = 3f;
        [SerializeField] private int _damage;

        private float _deathTime;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _rb.velocity = transform.up * _speed;
            this.StartTimer(_lifeTime, () => Destroy(gameObject));
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            
            if (other.gameObject.TryGetComponent(out Health healthp))
            {
                healthp.Change(-_damage);
            }

            Destroy(gameObject);
        }

        #endregion
    }
}