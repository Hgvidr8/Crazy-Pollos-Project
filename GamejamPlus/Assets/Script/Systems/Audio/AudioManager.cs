using System;
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
        //Play("Cena1Loop");
    }

    public void Play(string name) 
    { 
       Sound s = Array.Find(sounds,sounds => sounds.soundName == name);
       s.source.Play();
    }

    public void StopAll() 
    { 
        foreach (Sound s in sounds) 
        { 
            s.source.Stop();
        }
    }
}
