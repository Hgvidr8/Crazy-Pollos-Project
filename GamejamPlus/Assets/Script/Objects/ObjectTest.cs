using UnityEngine;

public class ObjectTest : MonoBehaviour, IObjectable, IInteractable
{
    
    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact()
    {
        print("Interacted");
    }

    public bool IsFromDistance()
    {
        return true;
    }
}
