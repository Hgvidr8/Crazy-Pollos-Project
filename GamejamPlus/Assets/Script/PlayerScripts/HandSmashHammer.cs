using UnityEngine;
using UnityEngine.InputSystem;

public interface ISmasheable
{
    public void OnSmash();
}
public class HandSmashHammer : Hand
{
    public override void Interact(InputAction.CallbackContext context)
    {
        if (context.phase.IsInProgress())
        {
            if(HandController.instance._object.GetTransform().TryGetComponent(out ISmasheable _smasheable))
            {
                _smasheable.OnSmash();
            }
        }
    }
}
