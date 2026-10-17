using UnityEngine;
using UnityEngine.Events;

public class BoateMinigame : MonoBehaviour
{
    [SerializeField] UnityEvent onSongStart, onSongEnd;

    public void StartSong()
    {
        onSongStart?.Invoke();
    }

    public void EndSong()
    {
        onSongEnd?.Invoke();
    }

}
