using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public abstract class Hand : MonoBehaviour
{
    public Material _handSpr;
    [SerializeField] protected UnityEvent OnHand;
    [SerializeField] protected float _maxDistance;
    public abstract void Interact(InputAction.CallbackContext context);
    public float GetMaxDistance()
    {
        return _maxDistance;
    }
}
