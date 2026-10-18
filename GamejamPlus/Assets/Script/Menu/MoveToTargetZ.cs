using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetZ : MonoBehaviour
{
    public GameObject objectToMove;
    public float speed = 2f;

    private static readonly Dictionary<Transform, (MoveToTargetZ owner, Coroutine routine)> active = new();

    public void StartMoving()
    {
        if (objectToMove == null)
        {
            return;
        }

        Transform t = objectToMove.transform;

        if (active.TryGetValue(t, out var running))
        {
            if (running.owner != null && running.routine != null)
            {
                running.owner.StopCoroutine(running.routine);
            }
            active.Remove(t);
        }

        Coroutine c = StartCoroutine(MoveRoutine(t));
        active[t] = (this, c);
    }

    private IEnumerator MoveRoutine(Transform t)
    {
        float startZ = t.position.z;
        float targetZ = transform.position.z;
        float distance = Mathf.Abs(targetZ - startZ);

        if (distance > 0.0001f && speed > 0f)
        {
            float duration = distance / speed;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                if (t == null)
                {
                    yield break;
                }

                elapsed += Time.deltaTime;
                float k = Mathf.SmoothStep(0f, 1f, Mathf.Clamp01(elapsed / duration));

                Vector3 pos = t.position;
                pos.z = Mathf.Lerp(startZ, targetZ, k);
                t.position = pos;
                yield return null;
            }
        }

        if (t != null)
        {
            Vector3 final = t.position;
            final.z = targetZ;
            t.position = final;
            active.Remove(t);
        }
    }
}