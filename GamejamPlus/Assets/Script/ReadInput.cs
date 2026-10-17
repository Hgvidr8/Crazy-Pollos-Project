using UnityEngine;
using UnityEngine.InputSystem;

public class ReadInput : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    public void GatherMoveInput(InputAction.CallbackContext _value)
    {
        _playerData.move = _value.ReadValue<Vector2>();
    }
    public void GatherLookInput(InputAction.CallbackContext _value)
    {
        _playerData.look = _value.ReadValue<Vector2>().normalized;
    }
}
