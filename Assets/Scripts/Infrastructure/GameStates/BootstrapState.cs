using Utils;

namespace Infrastructure.GameStates
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter() => 
            _sceneLoader.LoadScene(Constants.InitialScene, EnterLoadLevel);

        public void Exit()
        {
        }

        private void EnterLoadLevel() => 
            _gameStateMachine.Enter<LoadLevelState>();
    }
}