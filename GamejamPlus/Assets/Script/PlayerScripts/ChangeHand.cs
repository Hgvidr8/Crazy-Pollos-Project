using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeHand : MonoBehaviour
{
    [SerializeField] Hand[] _hands;
    int _axis;
    public void SetHand(InputAction.CallbackContext value)
    {
        _axis += (int)value.ReadValue<Vector2>().y;

        if (_axis <= 0)
        {
            _axis = 0;
        }
        if(_axis >= _hands.Length - 1)
        {
            _axis = _hands.Length - 1;
        }
        HandController.instance._hand = _hands[_axis];
    }
}
