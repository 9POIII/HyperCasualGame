using Resources.Scripts.Interfaces;
using UnityEngine;

namespace Resources.Scripts.Mechanics
{
    public class Shuffle : MonoBehaviour, IUseShuffle
    {
        public void ShuffleArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int randomIndex = Random.Range(i, array.Length);
                (array[randomIndex], array[i]) = (array[i], array[randomIndex]);
            }        
        }
    }
}
