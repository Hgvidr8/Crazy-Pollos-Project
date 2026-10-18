using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioData audioData;
    Sound[] sounds;

   public static AudioManager instance;

    private void Awake()
    {

        if (instance == null) 
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        sounds = audioData.sounds;

        foreach (Sound s in sounds) 
        { 
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.soundClip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.canLoop;
            
        }
    }

    private void Start()
    {
        Play("Cena1Intro");
    }

    public void Play(string name) 
    { 
       Sound s = Array.Find(sounds,sounds => sounds.soundName == name);
        if (s.hasSequence) 
        { 
            StartCoroutine(PlaySequence(s));
            return;
        }
        s.source.Play();
        Debug.Log("Playing: " + s.soundName);

    }

    IEnumerator PlaySequence(Sound s)
    {
        s.source.Play();
        Debug.Log("Playing: " + s.soundName);

        yield return new WaitForSeconds(s.soundClip.length-0.1f);
        Sound nextSound = Array.Find(sounds, sounds => sounds.soundName == s.sequenceName);
        if (nextSound != null)
        {
            nextSound.source.Play();
            Debug.Log("Playing: " + nextSound.soundName);

        }
    }

    public void StopAll() 
    { 
        foreach (Sound s in sounds) 
        { 
            s.source.Stop();
        }
    }
}
