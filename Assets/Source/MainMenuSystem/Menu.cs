using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenuSystem
{
    public class Menu : MonoBehaviour
    {
        public void LoadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void ExitGame()
        {
            Debug.Log("exit");
            Application.Quit();
        }
    }
}
