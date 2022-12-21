using UnityEngine;

namespace Utils
{
    public class ObjectSpawnerUtil : MonoBehaviour
    {
        [SerializeField] private GameObject objPrefabToSpawn;

        public void SpawnObject()
        {
            Instantiate(objPrefabToSpawn , transform.position , transform.rotation);
        }
    }
}
