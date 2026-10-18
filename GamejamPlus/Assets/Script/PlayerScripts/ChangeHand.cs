using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeHand : MonoBehaviour
{
    [SerializeField] Hand[] _hands;
    public void SetHand(InputAction.CallbackContext context)
    {
        char[] _gotChar = context.control.displayName.ToCharArray();
        HandController.instance._hand = _hands[_gotChar[_gotChar.Length - 1] - 49];
    }
}
