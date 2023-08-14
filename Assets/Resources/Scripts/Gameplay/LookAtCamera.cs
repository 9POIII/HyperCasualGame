using UnityEngine;

namespace Resources.Scripts.Gameplay
{
    public class LookAtCamera : MonoBehaviour
    {
        private Transform mainCamera;
        [SerializeField] private float rotationSpeed = 5f;

        public float RotationSpeed => rotationSpeed;
        
        void Start()
        {
            if (Camera.main != null) mainCamera = Camera.main.transform;
        }

        void Update()
        {
            Vector3 directionToCamera = mainCamera.position - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(-directionToCamera, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }
    }
}