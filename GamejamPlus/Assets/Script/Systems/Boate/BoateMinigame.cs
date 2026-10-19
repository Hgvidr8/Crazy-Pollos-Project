using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BoateMinigame : MonoBehaviour
{
    [SerializeField] UnityEvent onSongStart, onSongEnd;

    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }

    public void PlayAudio(string audioName)
    {
        AudioManager.instance.Play(audioName);
    }
    public void StopAudio(string audioName)
    {
        AudioManager.instance.Stop(audioName);
    }

    public IEnumerator StartGameCoroutine()
    {
        //começa o ciclo de pausar

        
        StartSong();
        yield return new WaitForSeconds(Random.Range(5f, 8f));
        StopSong();
        yield return new WaitForSeconds(Random.Range(1f, 5f));

        StartCoroutine(StartGameCoroutine());

    }

    public void EndGame() 
    { 
        StopCoroutine(StartGameCoroutine());
        StartSong();
    }

     void StartSong()
    {
        onSongStart?.Invoke();
    }

     void StopSong()
    {
        onSongEnd?.Invoke();
    }

}
