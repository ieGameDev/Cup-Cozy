using CameraLogic;
using Services.Factory;
using UnityEngine;
using Utils;

namespace Infrastructure.GameStates
{
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
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
            GameObject player = InitializingPlayer();
            InitializingCamera(player);
            InitializingHUD();
        }

        private GameObject InitializingPlayer()
        {
            return _gameFactory.CreatePlayer();
        }

        private void InitializingHUD()
        {
            _gameFactory.CreatePlayerHUD();
        }

        private void InitializingCamera(GameObject player)
        {
            Camera.main?.GetComponent<CameraFollow>().Follow(player);
        }
    }
}