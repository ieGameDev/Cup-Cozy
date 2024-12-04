using Infrastructure.DI;
using UnityEngine;

namespace Services.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer();
        GameObject CreatePlayerHUD();
    }
}