namespace Infrastructure.GameStates
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}