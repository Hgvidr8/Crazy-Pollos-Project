using UnityEngine;
using UnityEngine.Events;

public class ObjectTest : MonoBehaviour, IObjectable, IInteractable
{
    [SerializeField] bool _interactable;
    [SerializeField] UnityEvent OnDoor;
    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact()
    {
        OnDoor.Invoke();
    }

    public bool IsFromDistance()
    {
        return _interactable;
    }
}
