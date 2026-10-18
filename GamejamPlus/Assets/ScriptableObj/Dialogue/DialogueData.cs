using UnityEngine;

public class DialogueData : ScriptableObject
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
}
