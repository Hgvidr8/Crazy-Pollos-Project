using UnityEngine;

public class Colectable : MonoBehaviour, IInteractable
{
    public Transform GetTransform()
    {
        return gameObject.transform;
    }

    public void Interact()
    {
        ColectableManager.Instance.IncreaseColectableCount();
        Destroy(gameObject);
    }
}
