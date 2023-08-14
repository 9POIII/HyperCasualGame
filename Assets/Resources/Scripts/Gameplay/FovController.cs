using UnityEngine;

namespace Resources.Scripts.Gameplay
{
    public class FovController : MonoBehaviour
    {
        public static FovController Instance;
    
        [SerializeField] private float maxFOV;
        [SerializeField] private float minFOV;
        [SerializeField] private float T1;
        [SerializeField] private float T2;
        private Camera mainCamera;

        public float t1 => T1;
        public float t2 => T2;
        
    
        private void Awake()
        {
            mainCamera = Camera.main;
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void AddFov()
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, maxFOV, t1);
        }
    
        public void MinusFov()
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, minFOV, t2);
        }
    }
}
