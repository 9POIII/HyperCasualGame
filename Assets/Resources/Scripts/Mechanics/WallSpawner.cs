using UnityEngine;
using Random = UnityEngine.Random;

namespace Resources.Scripts.Mechanics
{
    public class WallSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] wallPrefs;
        [SerializeField] private Transform[] wallSpawnPoints;

        private void Awake()
        {
            WallSpawn();
        }

        private void WallSpawn()
        {
            var numObjects = Random.Range(2, wallPrefs.Length + 3);

            ShuffleManager.Instance.Shuffle(wallSpawnPoints);
            
            for (int i = 0; i < numObjects; i++)
            {
                int prefabIndex = Random.Range(0, wallPrefs.Length);

                Transform spawnPoint = wallSpawnPoints[i];

                GameObject spawnedObject = Instantiate(wallPrefs[prefabIndex], spawnPoint.position, spawnPoint.rotation);
                spawnedObject.transform.SetParent(spawnPoint.transform);
            }
        }
    }
}
