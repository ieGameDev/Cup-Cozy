using CameraLogic;
using UnityEngine;
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
            InitializingGameWorld();
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitializingGameWorld()
        {
            GameObject player = GameObject.FindWithTag("Player");
            InitializingCamera(player);
        }

        private void InitializingCamera(GameObject player)
        {
            Camera.main?.GetComponent<CameraFollow>().Follow(player);
        }
    }
}