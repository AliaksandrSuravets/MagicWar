using UnityEngine;

namespace MagicWar.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        #region Unity lifecycle

        private void Start()
        {
            StateMachine sm = new StateMachine();
            ServiceLocator.Instance.Register(sm);
            sm.Enter<BootstrapState>();
        }

        #endregion
    }
}