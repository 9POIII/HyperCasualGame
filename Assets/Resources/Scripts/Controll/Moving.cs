using UnityEngine;

namespace Resources.Scripts.Controll
{
    public class Moving : MonoBehaviour
    {
        [SerializeField] private Vector3 direction;
        [SerializeField] private float sideSpeed = 0;
        [SerializeField] private float border;
        
        private Vector3 sideDirection;
        private float playerSpeed = 0;

        public float PlayerSpeed
        {
            get { return playerSpeed; }
            set
            {
                if (value < 0 || value > 1)
                {
                    playerSpeed = 0.1f;
                }
                else
                    playerSpeed = value;
            }
        }

        private void FixedUpdate()
        {
            MoveForward();
            MoveSide(sideDirection);

            var transformPosition = gameObject.transform.position;
            if (transformPosition.z >= border)
            {
                gameObject.transform.position = new Vector3(transformPosition.x, transformPosition.y, border);
            }
            if (transformPosition.z <= -border)
            {
                gameObject.transform.position = new Vector3(transformPosition.x, transformPosition.y, -border);
            }
        }

        public void ChangeSideDirection(float z)
        {
            sideDirection.z = z;
        }

        private void MoveForward()
        {
            transform.Translate(direction.normalized * PlayerSpeed);
        }

        private void MoveSide(Vector3 sideDirection)
        {
            transform.Translate(new Vector3(0f, 0f, sideDirection.z) * sideSpeed);
        }
    }
}
