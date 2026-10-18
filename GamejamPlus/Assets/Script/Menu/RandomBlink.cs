using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomBlink : MonoBehaviour
{
    public Sprite openEyes;
    public Sprite closedEyes;
    public float minInterval = 2f;
    public float maxInterval = 5f;
    public float blinkDuration = 0.1f;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.sprite = openEyes;
        StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));

            spriteRenderer.sprite = closedEyes;
            yield return new WaitForSeconds(blinkDuration);
            spriteRenderer.sprite = openEyes;
        }
    }
}