using DG.Tweening;
using Resources.Scripts.Interfaces;
using TMPro;
using UnityEngine;

namespace Resources.Scripts.Mechanics
{
    public class DotweenAnims : MonoBehaviour, IUseDotween
    {
        public void DoShake(Transform gameObjectTransform, float duration, float strength)
        {
            var myTween = gameObjectTransform.DOShakePosition(duration, strength);
        }

        public void DoDumping(TMP_Text textObj, float to, float duration)
        {
            var myTween = textObj.DOFade(to, duration);
        }
    }
}
