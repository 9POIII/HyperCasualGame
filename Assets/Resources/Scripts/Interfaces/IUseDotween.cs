using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Resources.Scripts.Interfaces
{
    public interface IUseDotween
    {
        void DoShake(Transform gameObjectTransform, float duration, float strength);
        void DoDumping(TMP_Text textObj, float to, float duration);
    }
}
