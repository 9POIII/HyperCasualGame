using System.Collections;
using Resources.Scripts.Mechanics;
using TMPro;
using UnityEngine;

namespace Resources.Scripts.UI
{
    public class InGameUI : MonoBehaviour
    {
        public static InGameUI Instance;
        
        [SerializeField] private TMP_Text playerText;

        private void Awake()
        {
            playerText.gameObject.SetActive(false);
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void ActivatingText(string text)
        {
            playerText.text = text;
            playerText.gameObject.SetActive(true);
            StartCoroutine(TextDumping(playerText, 0, 1f));
        }

        private IEnumerator TextDumping(TMP_Text textObj, float to, float duration)
        {
            yield return new WaitForSeconds(0.5f);
            DotweenManager.Instance.Dumping(textObj, to, duration);
            yield return new WaitForSeconds(duration);
            playerText.gameObject.SetActive(false);
            playerText.alpha = 255;
        }
    }
}
