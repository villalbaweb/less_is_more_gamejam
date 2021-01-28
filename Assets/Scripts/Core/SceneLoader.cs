using UnityEngine;
using UnityEngine.SceneManagement;

namespace LessIsMore.Core
{
    public class SceneLoader : MonoBehaviour
    {
        public void QuitGame()
        {
            Application.Quit();
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("Start");
        }

        public void LoadPlayLevel()
        {
            SceneManager.LoadScene("Level");
        }
    }
}
