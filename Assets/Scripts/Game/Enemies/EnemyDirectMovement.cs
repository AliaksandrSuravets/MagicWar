using System;
using UnityEngine;

namespace MagicWar.Game.Enemies
{
    public class EnemyDirectMovement : EnemyMovement
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 3f;
        [SerializeField] private EnemyAnimation _animation;
        private Vector3 _startVector;

        private Transform _target;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _startVector = transform.position;
        }

        private void Update()
        {
            if (_target == null)
            {
                MoveToStart();
                return;
            }

            MoveToTarget();
        }

        private void OnDisable()
        {
            _rb.velocity = Vector2.zero;
        }

        #endregion

        #region Public methods

        public override void SetTarget(Transform target)
        {
            _target = target;
        }

        #endregion

        #region Private methods

        private void MoveToStart()
        {
            Vector3 direction = (_startVector - transform.position).normalized;
            Rotate(direction);
            _rb.velocity = direction * +_speed;
            _animation.SetSpeed(1);

            if (Vector2.Distance(transform.position, _startVector) < 0.2f)
            {
                _animation.SetSpeed(0);
                _rb.velocity = Vector2.zero;
            }
        }

        private void MoveToTarget()
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Rotate(direction);
            _rb.velocity = direction * +_speed;
            _animation.SetSpeed(1);
        }

        private void Rotate(Vector3 direction)
        {
            transform.up = direction;
        }

        #endregion
    }
}