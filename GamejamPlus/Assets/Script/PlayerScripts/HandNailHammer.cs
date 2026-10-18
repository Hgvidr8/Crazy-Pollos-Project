using UnityEngine;
using UnityEngine.InputSystem;

public interface INaileable
{
    public void OnNailOut();
}
public class HandNailHammer : Hand
{
    public override void Interact(InputAction.CallbackContext context)
    {
        if (context.phase.IsInProgress())
        {
            if (HandController.instance._object.GetTransform().TryGetComponent(out INaileable _naileable))
            {
                _naileable.OnNailOut();
            }
        }
    }
}
