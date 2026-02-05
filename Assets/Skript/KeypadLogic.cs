using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeypadLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI screen;
    [SerializeField] private string codeWord;
    [SerializeField] private int codeLength;
    [SerializeField] private GameObject keypad;
    [SerializeField] private int sceneNumber;

    public void AddNumber(string number)
    {
        if (screen.text.Length <= codeLength -1 )
        {
            screen.text += number;
        }
    }

    public void Clear()
    {
        screen.text = "";
    }

    public void CheckCode()
    {
        if (screen.text == codeWord)
        {
            keypad.SetActive(false);
            SceneManager.LoadScene(sceneNumber);
            Debug.Log("Correct Code");
        }
        else
        {
            Debug.Log("Wrong Code");
        }
    }
}
