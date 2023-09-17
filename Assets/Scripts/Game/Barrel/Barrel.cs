using System;
using UnityEngine;

namespace MagicWar.Game.Barrel
{
    public class Barrel : MonoBehaviour
    {
        [Header("Boom")]
        [SerializeField] private BoomBarrel _boomBarrel;
        [Header("VFX")]
        [SerializeField] private GameObject _destroyVFX;
        private void OnCollisionEnter2D(Collision2D other)
        {
            _boomBarrel.OnDestroyedActions();
            
            if (_destroyVFX == null)
            {
                return;
            }

            Instantiate(_destroyVFX, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
        }
    }
}