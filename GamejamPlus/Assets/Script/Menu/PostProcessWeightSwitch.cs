using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PostProcessWeightSwitch : MonoBehaviour
{
    public Volume volumeA;
    public Volume volumeB;
    public Volume volumeC;
    public float firstFadeDuration = 1f;
    public float delay = 1f;
    public float secondFadeDuration = 1f;

    private Coroutine routine;

    public void Trigger()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
        }

        routine = StartCoroutine(SwitchRoutine());
    }

    private IEnumerator SwitchRoutine()
    {
        yield return Fade(firstFadeDuration, 0f, 1f, 0f);

        yield return new WaitForSeconds(delay);

        yield return Fade(secondFadeDuration, 0f, 0f, 1f);

        routine = null;
    }

    private IEnumerator Fade(float duration, float targetA, float targetB, float targetC)
    {
        float startA = GetWeight(volumeA);
        float startB = GetWeight(volumeB);
        float startC = GetWeight(volumeC);

        if (duration > 0f)
        {
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float k = Mathf.SmoothStep(0f, 1f, Mathf.Clamp01(elapsed / duration));

                SetWeight(volumeA, Mathf.Lerp(startA, targetA, k));
                SetWeight(volumeB, Mathf.Lerp(startB, targetB, k));
                SetWeight(volumeC, Mathf.Lerp(startC, targetC, k));

                yield return null;
            }
        }

        SetWeight(volumeA, targetA);
        SetWeight(volumeB, targetB);
        SetWeight(volumeC, targetC);
    }

    private float GetWeight(Volume volume)
    {
        return volume != null ? volume.weight : 0f;
    }

    private void SetWeight(Volume volume, float weight)
    {
        if (volume != null)
        {
            volume.weight = weight;
        }
    }
}