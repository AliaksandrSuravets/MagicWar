using UnityEngine;
using UnityEngine.Events;

namespace MagicWar.Service.Events
{
    [System.Serializable]
    public class CustomGameEvent: UnityEvent<Component, object> {}
    
    public class GameEventListener : MonoBehaviour
    {
        #region Variables

        [Tooltip("Event to register with.")]
        [SerializeField] private GameEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        [SerializeField] private CustomGameEvent Response;

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        #endregion

        #region Public methods

        public void OnEventRaised(Component sender, object data)
        {
            Response.Invoke(sender, data);
        }
        #endregion
    }
}