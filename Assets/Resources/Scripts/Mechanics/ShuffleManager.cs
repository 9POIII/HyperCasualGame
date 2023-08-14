using Resources.Scripts.Interfaces;
using UnityEngine;

namespace Resources.Scripts.Mechanics
{
    public class ShuffleManager : MonoBehaviour
    {
        public static ShuffleManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void Shuffle<T>(T[] array)
        {
            var setArray = SetArray();
            if (setArray != null)
            {
                setArray.ShuffleArray(array);
            }
        }

        private IUseShuffle SetArray()
        {
            return gameObject.GetComponent<IUseShuffle>();
        }
    }
}
