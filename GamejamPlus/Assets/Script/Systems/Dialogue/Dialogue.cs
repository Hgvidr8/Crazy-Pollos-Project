using UnityEngine;

public class Dialogue : MonoBehaviour, IInteractable
{
    [SerializeField] string _name;
    [SerializeField] string[] sentences;
    
    public string GetName()
    {
        return _name;
    }
    public string[] GetSentences()
    {
        return sentences;
    }

    public void Interact()
    {
       
    }
}
