using Unity.Mathematics;
using UnityEngine;

namespace Resources.Scripts.Mechanics
{
    public class StartSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject wallPrefab;
        [SerializeField] private GameObject entityPrefab;
        [SerializeField] private GameObject roadModel;
        [SerializeField] private GameObject finishPlane;
        [SerializeField] private int gameLength;

        public int GameLength{
            get => gameLength;
            set => gameLength = value;
        }
        
        private void Start()
        {
            for (int i = 25; i <= GameLength; i += 25)
            {
                Instantiate(entityPrefab, new Vector3(i - 12.5f, 0, 0), Quaternion.identity);
                Instantiate(wallPrefab, new Vector3(i, 0, 0), Quaternion.identity);
                Instantiate(roadModel, new Vector3(i, -1, 0), Quaternion.identity);
            }

            Instantiate(finishPlane, new Vector3(GameLength + 12, -0.49f, 0), Quaternion.identity);
        }
    }
}