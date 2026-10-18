using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class PointerTracker : MonoBehaviour
{
    public Camera targetCamera;
    public float fixedX = 0f;
    public float smoothing = 0f;

    private void Awake()
    {
        if (targetCamera == null)
        {
            targetCamera = Camera.main;
        }
    }

    private void Update()
    {
        if (targetCamera == null)
        {
            return;
        }

        Vector2 screenPos = GetPointerPosition();
        Ray ray = targetCamera.ScreenPointToRay(screenPos);
        Plane plane = new Plane(Vector3.right, new Vector3(fixedX, 0f, 0f));

        if (!plane.Raycast(ray, out float enter))
        {
            return;
        }

        Vector3 target = ray.GetPoint(enter);
        target.x = fixedX;

        if (smoothing <= 0f)
        {
            transform.position = target;
        }
        else
        {
            float t = 1f - Mathf.Exp(-smoothing * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, target, t);
        }
    }

    private Vector2 GetPointerPosition()
    {
#if ENABLE_INPUT_SYSTEM
        if (Pointer.current != null)
        {
            return Pointer.current.position.ReadValue();
        }
        return Vector2.zero;
#else
        return Input.mousePosition;
#endif
    }
}