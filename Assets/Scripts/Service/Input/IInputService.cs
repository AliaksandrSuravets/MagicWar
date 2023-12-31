using MagicWar.Infrastructure;
using UnityEngine;

namespace MagicWar.Service.Input
{
    public interface IInputService : IService
    {
        #region Properties

        Vector2 Axes { get; }
        Vector3 LookDirection { get; }

        #endregion

        #region Public methods

        void Dispose();
        void Initialize(Camera camera, Transform playerMovementTransform);

        #endregion
    }
}