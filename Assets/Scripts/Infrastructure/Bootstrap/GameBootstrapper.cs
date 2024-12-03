using Infrastructure.GameStates;
using UnityEngine;
using Utils;

namespace Infrastructure.Bootstrap
{
    public class GameBootstrapper : MonoBehaviour
    {
        private GameStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new GameStateMachine(new SceneLoader());
            _stateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}
