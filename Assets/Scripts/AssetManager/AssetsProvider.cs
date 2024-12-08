using UnityEngine;

namespace AssetManager
{
    public class AssetsProvider : IAssetsProvider
    {
        public GameObject Instantiate(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public GameObject Instantiate(string path, Vector3 initialPoint)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, initialPoint, Quaternion.identity);
        }
        
        public GameObject Instantiate(GameObject prefab, Vector3 initialPoint)
        {
            return Object.Instantiate(prefab, initialPoint, Quaternion.identity);
        }
    }
}