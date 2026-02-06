using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string mainMenu;
    [SerializeField] private string startScene;
    [SerializeField] private string gameScene;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(startScene);
    }
    
}
