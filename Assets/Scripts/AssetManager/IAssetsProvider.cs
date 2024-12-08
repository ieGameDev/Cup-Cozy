using Infrastructure.DI;
using UnityEngine;

namespace AssetManager
{
    public interface IAssetsProvider : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 initialPoint);
        GameObject Instantiate(GameObject prefab, Vector3 initialPoint);
    }
}