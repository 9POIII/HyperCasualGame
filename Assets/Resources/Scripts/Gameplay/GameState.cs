using Resources.Scripts.Mechanics;
using Sound;
using UnityEngine;

namespace Resources.Scripts.Gameplay
{
    public class GameState : MonoBehaviour
    {
        private bool canPlay;
        [SerializeField] private AudioClip gameOverSound;
        [SerializeField] private AudioClip gameWinSound;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private GameObject winPanel;
        //[SerializeField] private InterstitialAds interstitialAds;
        //[SerializeField] private ScoreChanger scoreChanger;

        public bool CanPlay
        {
            get => canPlay;
            set => canPlay = value;
        }

        public static GameState Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            Application.targetFrameRate = Screen.currentResolution.refreshRate < 120 ? 60 : 120;
            CanPlay = false;
            losePanel.SetActive(false);
            winPanel.SetActive(false);
        }

        public void WinGame()
        {
            CanPlay = false;
            winPanel.SetActive(true);
            SoundManager.Instance.Play(gameWinSound, 0.5f);
        }

        public void LoseGame()
        {
            if (Camera.main != null) DotweenManager.Instance.Shake(Camera.main.gameObject.transform, 0.5f, 1f);
            CanPlay = false;
            SoundManager.Instance.Play(gameOverSound, 0.5f);
            losePanel.SetActive(true);
            //interstitialAds.ShowAd();
            //scoreChanger.SaveScore();
        }
    }
}
