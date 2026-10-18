using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class StartEvent : MonoBehaviour
{
    public UnityEvent onStart;
    public UnityEvent onDelayedStart;
    public float delay = 2f;

    private void Start()
    {
        onStart?.Invoke();
        StartCoroutine(DelayedRoutine());
    }

    private IEnumerator DelayedRoutine()
    {
        yield return new WaitForSeconds(delay);
        onDelayedStart?.Invoke();
    }
}