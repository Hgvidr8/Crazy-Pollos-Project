using UnityEngine;

public class Dialogue : MonoBehaviour, IInteractable
{
    [SerializeField] DialogueData data;
    string _name;
    string[] sentences;

    private void Start()
    {
        _name = data.GetName();
        sentences = data.GetSentences();
    }

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
       DialogueManager.Instance.StartDialogue(this);
    }

    public Transform GetTransform()
    {
        return gameObject.transform;
    }
}
