using System.Collections.Generic;
using UnityEngine;

namespace Resources.Scripts.Mechanics
{
    public class EntitySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject pickupCubePrefab;
        [SerializeField] private int gridSizeX = 20;
        [SerializeField] private int gridSizeY = 5;
        
        private HashSet<Vector3> spawnedPositions = new HashSet<Vector3>();

        public int GridSizeX => gridSizeX;
        public int GridSizeY => gridSizeY;

        private void Awake()
        {
            int maxObjects = Random.Range(1, 3);
            
            for (int i = 0; i < maxObjects; i++)
            {
                Vector3 spawnPosition = GetRandomPosition(); ;
                SpawnEntity(spawnPosition, pickupCubePrefab);
                spawnedPositions.Add(spawnPosition);
            }
        }
        
        Vector3 GetRandomPosition()
        {
            Vector3 spawnPosition = Vector3.zero;
            int attempts = 0;
            int maxAttempts = 100;

            do
            {
                float x = Random.Range(0, GridSizeX);
                float z = Random.Range(0, GridSizeY);
                spawnPosition = new Vector3(x, 0, z - 2);
                attempts++;
            } while (spawnedPositions.Contains(spawnPosition) && attempts < maxAttempts);

            return spawnPosition;
        }

        private void SpawnEntity(Vector3 position, GameObject objectToSpawn)
        {
            GameObject spawned = Instantiate(objectToSpawn, transform.TransformPoint(position), Quaternion.identity);
            spawned.transform.parent = transform;
        }
    }
}
