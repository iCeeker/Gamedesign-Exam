using UnityEngine;

public class NpcInteraction : MonoBehaviour, IInteraction
{
    private bool hasBeenInteracted = false;
    [SerializeField] private TextAsset textAsset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log(textAsset.text);
    }

    public bool IsInteractable()
    {
        return !hasBeenInteracted;
    }
}
