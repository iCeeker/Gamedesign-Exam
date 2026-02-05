using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class KeypadLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI screen;
    [SerializeField] private string codeWord;

    public void AddNumber(string number)
    {
        if (screen.text.Length <= 5)
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
            Debug.Log("Correct Code");
        }
        else
        {
            Debug.Log("Wrong Code");
        }
    }
    
    
}
