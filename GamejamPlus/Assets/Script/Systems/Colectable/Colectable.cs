using UnityEngine;

public class Colectable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        ColectableManager.Instance.IncreaseColectableCount();
        Destroy(gameObject);
    }
}
