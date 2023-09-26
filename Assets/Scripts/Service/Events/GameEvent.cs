using System.Collections.Generic;
using UnityEngine;

namespace MagicWar.Service.Events
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        #region Variables

        private readonly List<GameEventListener> eventListeners =
            new List<GameEventListener>();

        #endregion

        #region Public methods

        public void Raise(Component sender, object data)
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
            {
                eventListeners[i].OnEventRaised(sender, data);
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
            {
                eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (eventListeners.Contains(listener))
            {
                eventListeners.Remove(listener);
            }
        }

        #endregion
    }
}