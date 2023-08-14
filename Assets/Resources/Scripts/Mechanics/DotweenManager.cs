using Resources.Scripts.Interfaces;
using TMPro;
using UnityEngine;

namespace Resources.Scripts.Mechanics
{
    public class DotweenManager : MonoBehaviour
    {
        public static DotweenManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        
        public void Shake(Transform gameObjecttraTransform, float duration, float strength)
        {
            var doShake = DoSomething();
            if (doShake != null)
            {
                doShake.DoShake(gameObjecttraTransform, duration, strength);
            }
        }

        public void Dumping(TMP_Text textObj, float to, float duration)
        {
            var doDumping = DoSomething();
            if (doDumping != null)
            {
                doDumping.DoDumping(textObj, to, duration);
            }
        }

        private IUseDotween DoSomething()
        {
            return gameObject.GetComponent<IUseDotween>();
        }
    }
}
