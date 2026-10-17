using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] Transform _cameraTransform;
    [SerializeField] float _maxDistance;
    public void HandInput()
    {

    }
    IInteractable GetInteractable()
    {
        RaycastHit _hit;
        if(Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out _hit, _maxDistance))
        {
            if(_hit.collider.TryGetComponent(out IInteractable _interactable))
            {
                return _interactable;
            }
        }
        return null;
    }
}
