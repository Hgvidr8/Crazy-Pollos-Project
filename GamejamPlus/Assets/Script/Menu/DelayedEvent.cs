using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DelayedEvent : MonoBehaviour
{
    public UnityEvent onTriggered;
    public float delay = 1f;

    private Coroutine routine;

    public void Trigger()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
        }

        routine = StartCoroutine(DelayRoutine());
    }

    public void Cancel()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
            routine = null;
        }
    }

    private IEnumerator DelayRoutine()
    {
        yield return new WaitForSeconds(delay);
        routine = null;
        onTriggered?.Invoke();
    }
}