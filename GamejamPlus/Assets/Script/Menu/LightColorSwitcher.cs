using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightColorSwitcher : MonoBehaviour
{
    public Color colorA = Color.red;
    public Color colorB = Color.blue;
    public float interval = 2f;

    private Light targetLight;
    private float timer;
    private bool usingA = true;

    private void Awake()
    {
        targetLight = GetComponent<Light>();
        targetLight.color = colorA;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer -= interval;
            usingA = !usingA;
            targetLight.color = usingA ? colorA : colorB;
        }
    }
}