using System;
using MagicWar.Service.Events;
using UnityEngine;

namespace MagicWar.Game
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private GameEvent _onTeleport;
        private void OnTriggerStay2D(Collider2D other)
        {
            _onTeleport.Raise(this, null);
        }
    }
}