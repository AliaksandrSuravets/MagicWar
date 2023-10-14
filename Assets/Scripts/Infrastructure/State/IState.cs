namespace MagicWar.Infrastructure
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}