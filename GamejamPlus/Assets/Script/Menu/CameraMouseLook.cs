using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMouseLook : MonoBehaviour
{
    [SerializeField] private float intensity = 0.05f;
    [SerializeField] private float maxAngle = 3f;
    [SerializeField] private float smoothness = 8f;

    private Quaternion startLocalRotation;
    private Vector2 currentAngles;

    private void Start()
    {
        startLocalRotation = transform.localRotation;
    }

    private void LateUpdate()
    {
        Vector2 delta = Mouse.current != null ? Mouse.current.delta.ReadValue() : Vector2.zero;

        Vector2 targetAngles = new Vector2(-delta.y, delta.x) * intensity;
        targetAngles = Vector2.ClampMagnitude(targetAngles, maxAngle);

        float t = 1f - Mathf.Exp(-smoothness * Time.deltaTime);
        currentAngles = Vector2.Lerp(currentAngles, targetAngles, t);

        transform.localRotation = startLocalRotation * Quaternion.Euler(currentAngles.x, currentAngles.y, 0f);
    }
}