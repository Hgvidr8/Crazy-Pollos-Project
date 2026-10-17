using UnityEngine;

public class ObjectTest : MonoBehaviour, IInteractable
{
    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact()
    {
        
    }
}
