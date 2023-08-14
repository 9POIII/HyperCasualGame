using Resources.Scripts.Gameplay;
using Unity.VisualScripting;
using UnityEngine;

namespace Resources.Scripts.Controll
{
    public class SimplyPlayerController : MonoBehaviour
    {
        public float ForwardMovementSpeed; // Скорость движения
        public float SideMovementSpeed;
        public float Corner;

        void FixedUpdate()
        {
            if (transform.position.z > Corner)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, Corner);
            }
            if (transform.position.z < -Corner)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -Corner);
            }

            if (GameState.Instance.CanPlay)
            {
                // Перемещение вперед по оси X при нажатии на клавишу W
                if (Input.GetKey(KeyCode.W))
                {
                    FovController.Instance.AddFov();
                    transform.Translate(Vector3.right * ForwardMovementSpeed * Time.deltaTime);
                }
                else
                {
                    FovController.Instance.MinusFov();
                }
            
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(Vector3.right * -ForwardMovementSpeed * Time.deltaTime);
                }

                // Перемещение влево по оси Z при нажатии на клавишу A
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(Vector3.forward * SideMovementSpeed * Time.deltaTime);
                }

                // Перемещение вправо по оси Z при нажатии на клавишу D
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(Vector3.back * SideMovementSpeed * Time.deltaTime);
                }
            }
        }
    }
}
