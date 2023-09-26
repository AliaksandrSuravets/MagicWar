using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MagicWar
{
    public class TrapActivate : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _tilemap;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tag.Player))
            {
                _tilemap.SetActive(true);
                Destroy(gameObject);
            }
        }

        #endregion
    }
}