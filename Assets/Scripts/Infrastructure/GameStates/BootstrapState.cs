using Services.Input;
using Utils;
using UnityEngine;

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
            RegisterServices();
        }

        public void Enter() => 
            _sceneLoader.LoadScene(Constants.InitialScene, EnterLoadLevel);

        public void Exit()
        {
        }

        private void EnterLoadLevel() => 
            _gameStateMachine.Enter<LoadLevelState>();

        private void RegisterServices()
        {
            InitialInputService();
        }
        
        private IInputService InitialInputService()
        {
            if (Application.isEditor)
                return new DesktopInput();
            else
                return new MobileInput();
        }
    }
}