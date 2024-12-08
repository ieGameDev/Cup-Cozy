using CameraLogic;
using Characters.Customers;
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
            OrderTrigger[] orderTriggers = InitializingOrderTriggers();
            InitializingCustomerSpawners(orderTriggers);
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

        private OrderTrigger[] InitializingOrderTriggers() =>
            Object.FindObjectsByType<OrderTrigger>(FindObjectsSortMode.None);

        private void InitializingCustomerSpawners(OrderTrigger[] orderTriggers)
        {
            CustomerSpawner[] spawners = Object.FindObjectsByType<CustomerSpawner>(FindObjectsSortMode.None);

            foreach (CustomerSpawner spawner in spawners)
                spawner.Construct(_gameFactory, orderTriggers);
        }
    }
}