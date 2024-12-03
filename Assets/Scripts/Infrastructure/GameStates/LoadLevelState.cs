using Utils;

namespace Infrastructure.GameStates
{
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(Constants.MainScene, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            _gameStateMachine.Enter<GameLoopState>();
        }
    }
}