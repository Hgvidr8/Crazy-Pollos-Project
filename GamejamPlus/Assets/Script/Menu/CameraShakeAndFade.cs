using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraShakeAndFade : MonoBehaviour
{
    public Volume volumeUp;
    public Volume volumeDown;
    public float shakeIntensity = 0.3f;
    public float shakeDuration = 0.8f;
    public float delay = 0.3f;
    public float fadeDuration = 1.5f;

    private Coroutine routine;
    private Vector3 currentOffset;

    public void Trigger()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
        }

        RemoveOffset();
        routine = StartCoroutine(SequenceRoutine());
    }

    private void OnDisable()
    {
        RemoveOffset();
        routine = null;
    }

    private void RemoveOffset()
    {
        transform.localPosition -= currentOffset;
        currentOffset = Vector3.zero;
    }

    private IEnumerator SequenceRoutine()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            elapsed += Time.deltaTime;
            float k = Mathf.Clamp01(elapsed / shakeDuration);
            float strength = shakeIntensity * (1f - k) * (1f - k);

            Vector3 newOffset = Random.insideUnitSphere * strength;
            transform.localPosition += newOffset - currentOffset;
            currentOffset = newOffset;

            yield return null;
        }

        RemoveOffset();

        yield return new WaitForSeconds(delay);

        float startUp = volumeUp != null ? volumeUp.weight : 0f;
        float startDown = volumeDown != null ? volumeDown.weight : 0f;
        elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float k = Mathf.SmoothStep(0f, 1f, Mathf.Clamp01(elapsed / fadeDuration));

            if (volumeUp != null)
            {
                volumeUp.weight = Mathf.Lerp(startUp, 1f, k);
            }

            if (volumeDown != null)
            {
                volumeDown.weight = Mathf.Lerp(startDown, 0f, k);
            }

            yield return null;
        }

        if (volumeUp != null)
        {
            volumeUp.weight = 1f;
        }

        if (volumeDown != null)
        {
            volumeDown.weight = 0f;
        }

        routine = null;
    }
}