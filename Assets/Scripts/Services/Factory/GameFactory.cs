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

        private GameObject _player;

        public GameFactory(IAssetsProvider assetsProvider, IInputService input)
        {
            _assetsProvider = assetsProvider;
            _input = input;
        }

        public GameObject CreatePlayer()
        {
            _player = _assetsProvider.Instantiate(AssetAddress.PlayerPath, new Vector3(0, 1.5f, 0));

            PlayerMove playerMove = _player.GetComponent<PlayerMove>();
            playerMove.Construct(_input);

            return _player;
        }

        public GameObject CreatePlayerHUD()
        {
            return _assetsProvider.Instantiate(AssetAddress.HUDPath);
        }

        public GameObject CreateCustomer(Transform spawnPoint)
        {
            GameObject[] customerPrefabs = Resources.LoadAll<GameObject>(AssetAddress.CustomersPath);
            GameObject randomCustomerPrefab = customerPrefabs[Random.Range(0, customerPrefabs.Length)];

            return _assetsProvider.Instantiate(randomCustomerPrefab, spawnPoint.position);
        }
    }
}