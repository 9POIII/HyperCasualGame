using Resources.Scripts.Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Resources.Scripts.UI
{
    public class GameMenu : MonoBehaviour
    {
        [SerializeField] private GameObject startScreenObjects;

        public void StartGame()
        {
            GameState.Instance.CanPlay = true;
            startScreenObjects.SetActive(false);
        }
        
        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
