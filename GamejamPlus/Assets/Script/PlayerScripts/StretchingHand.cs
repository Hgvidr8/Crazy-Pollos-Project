using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class StretchingHand : Hand
{
    public override void Interact(InputAction.CallbackContext context)
    {
        if (context.phase.IsInProgress())
        {
            if (HandController.instance._isHolding)
            {
                if (HandController.instance._handObj.GetChild(0).TryGetComponent(out IObjectable _interactable))
                {
                    if (!_interactable.IsFromDistance())
                    {
                        return;
                    }
                }
                RaycastHit _hit;
                if (Physics.Raycast(HandController.instance._cameraTransform.position, HandController.instance._cameraTransform.forward, out _hit, HandController.instance._maxDistance))
                {
                    HandController.instance._canAdjustHand = false;
                    HandController.instance._handObj.DOMove(_hit.point += _hit.normal / 2, .25f).OnComplete(Complete);
                    return;
                }
            }

            if (HandController.instance._object.IsFromDistance())
            {
                HandController.instance._object.GetTransform().SetParent(HandController.instance._handObj);
                HandController.instance._canAdjustHand = false;
                HandController.instance._handObj.DOMove(HandController.instance._referencePoint.position, .25f).OnComplete(() => HandController.instance._canAdjustHand = true);
                if (HandController.instance._object.GetTransform().TryGetComponent(out IInteractable _interactable))
                {
                    HandController.instance._isHolding = true;
                    _interactable.Interact();
                }
            }
            else
            {
                if (HandController.instance._object.GetTransform().TryGetComponent(out IInteractable _interactable))
                {
                    _interactable.Interact();
                }
            }
        }
    }
    public void Complete()
    {
        HandController.instance._handObj.GetChild(0).SetParent(null);
        HandController.instance._isHolding = false;
        HandController.instance._canAdjustHand = true;
    }
}
