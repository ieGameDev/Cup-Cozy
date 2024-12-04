using AssetManager;
using Characters.Player;
using Services.Input;
using UnityEngine;

namespace Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IInputService _input;
        private readonly IAssetsProvider _assetsProvider;

        public GameObject Player { get; set; }

        public GameFactory(IAssetsProvider assetsProvider, IInputService input)
        {
            _assetsProvider = assetsProvider;
            _input = input;
        }

        public GameObject CreatePlayer()
        {
            Player = _assetsProvider.Instantiate(AssetAddress.PlayerPath, new Vector3(0, 1.5f, 0));

            PlayerMove playerMove = Player.GetComponent<PlayerMove>();
            playerMove.Construct(_input);

            return Player;
        }

        public GameObject CreatePlayerHUD()
        {
            return _assetsProvider.Instantiate(AssetAddress.HUDPath);
        }
    }
}