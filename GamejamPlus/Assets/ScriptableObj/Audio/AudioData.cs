using UnityEngine;
[CreateAssetMenu(fileName = "AudioData", menuName = "Scriptable Objects/AudioData")]
public class AudioData : ScriptableObject
{
    [SerializeField] Sound[] Sounds;

    public Sound[] sounds { get { return Sounds; } }
}
