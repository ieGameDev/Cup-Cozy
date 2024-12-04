using AssetManager;
using Infrastructure.DI;
using Services.Factory;
using Services.Input;
using Utils;
using UnityEngine;

namespace Infrastructure.GameStates
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly DiContainer _container;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, DiContainer container)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _container = container;

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
            _container.RegisterSingle(InitialInputService());
            _container.RegisterSingle<IAssetsProvider>(new AssetsProvider());
            
            _container.RegisterSingle<IGameFactory>(new GameFactory
                (
                    _container.Single<IAssetsProvider>(),
                    _container.Single<IInputService>()
                )
            );
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