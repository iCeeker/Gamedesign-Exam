using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameScene;
    
    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameScene);
    }
    
}
