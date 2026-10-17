using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] Transform _cameraTransform;
    [SerializeField] float _speedValue;
    [SerializeField] float _cameraSens;
    Vector2 _inputValue;
    public void Walk(InputAction.CallbackContext _value)
    {
        _inputValue = _value.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        Vector3 _moveDirection = _cameraTransform.forward * _inputValue.y + _cameraTransform.right * _inputValue.x;
        _rb.AddForce(_moveDirection * _speedValue, ForceMode.Force);
    }
    Vector2 _rotation;
    public void Camera(InputAction.CallbackContext _value)
    {
        float _inputX = _value.ReadValue<Vector2>().x * _cameraSens;
        float _inputY = _value.ReadValue<Vector2>().y * _cameraSens;

        _rotation.y += _inputX;
        _rotation.x -= _inputY;
        _rotation.x = Mathf.Clamp(_rotation.x, -90f, 90f);

        _cameraTransform.rotation = Quaternion.Euler(_rotation.x, _rotation.y, 0);
    }
}
