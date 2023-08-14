using Resources.Scripts.Gameplay;
using UnityEngine;

namespace Resources.Scripts.Controll
{
    public class MobileControl : MonoBehaviour
    {
        [SerializeField] private Moving moving;

        private void Start()
        {
            moving.PlayerSpeed = 0;
        }

        private void Update()
        {
            if (GameState.Instance.CanPlay)
            {
                if (Input.touchCount > 0)
                {
                    StartMoving();

                    Touch screenTouch = Input.GetTouch(0);
                    if (screenTouch.phase == TouchPhase.Moved)
                    {
                        moving.ChangeSideDirection(screenTouch.deltaPosition.x * -1);
                    }
                }
                else
                    EndMoving();
            }
            else
            {
                EndMoving();
            }
        }

        private void StartMoving()
        {
            moving.PlayerSpeed = 0.2f;
        }

        private void EndMoving()
        {
            moving.PlayerSpeed = 0f;
            moving.ChangeSideDirection(0);
        }
    }
}
