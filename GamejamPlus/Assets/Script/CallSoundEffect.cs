using UnityEngine;

public class CallSoundEffect : MonoBehaviour
{
    public string Audio;

    public void PlayAudio()
    {
        AudioManager.instance.Play(Audio);
    }
}
