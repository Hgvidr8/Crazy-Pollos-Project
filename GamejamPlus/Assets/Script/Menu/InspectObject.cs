using System.Collections;
using UnityEngine;

public class InspectObject : MonoBehaviour
{
    public Transform inspectingPoint;
    public float travelDuration = 1.5f;
    public float returnDuration = 1.2f;

    private Vector3 startPosition;
    private Coroutine routine;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void StartInspecting()
    {
        if (inspectingPoint == null)
        {
            return;
        }

        MoveTo(inspectingPoint.position, travelDuration);
    }

    public void ReturnToStart()
    {
        MoveTo(startPosition, returnDuration);
    }

    private void MoveTo(Vector3 destination, float duration)
    {
        if (routine != null)
        {
            StopCoroutine(routine);
        }

        routine = StartCoroutine(MoveRoutine(destination, duration));
    }

    private IEnumerator MoveRoutine(Vector3 destination, float duration)
    {
        Vector3 from = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float k = Mathf.SmoothStep(0f, 1f, Mathf.Clamp01(elapsed / duration));
            transform.position = Vector3.Lerp(from, destination, k);
            yield return null;
        }

        transform.position = destination;
        routine = null;
    }
}