using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class HandController : MonoBehaviour
{
    [SerializeField] IObjectable _object;
    [SerializeField] Transform _referencePoint;
    [SerializeField] Transform _cameraTransform;
    [SerializeField] Transform _handObj;
    [SerializeField] float _maxDistance;
    bool _isHolding;
    bool _canAdjustHand = true;
    Vector3 _handPositionOnObj;
    private void FixedUpdate()
    {
        HandCast(out _object, out _handPositionOnObj);
        if(_canAdjustHand)
        _handObj.DOMove(_handPositionOnObj, .25f);
    }
    void HandCast(out IObjectable _objectOverride, out Vector3 _handPos)
    {
        RaycastHit _hit;
        if(Physics.Raycast(_cameraTransform.position, _cameraTransform.forward,out _hit, _maxDistance))
        {
            if(_hit.collider.TryGetComponent(out IObjectable _objectable))
            {
                if (!_isHolding)
                {
                    _handPos = _hit.point;
                    _objectOverride = _objectable;
                    return;
                }
            }
            Debug.DrawRay(_cameraTransform.position, _cameraTransform.forward * _maxDistance, Color.yellow, 0f);
        }
        _objectOverride = null;
        _handPos = _referencePoint.position;
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.phase.IsInProgress())
        {
            if (_isHolding)
            {
                if(_handObj.GetChild(0).TryGetComponent(out IObjectable _interactable))
                {
                    if (!_interactable.IsFromDistance())
                    {
                        return;
                    }
                }
                RaycastHit _hit;
                if(Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out _hit, _maxDistance))
                {
                    _canAdjustHand = false;
                    _handObj.DOMove(_hit.point, .25f).OnComplete(Complete);
                    return;
                }
            }

            if (_object.IsFromDistance())
            {
                _object.GetTransform().SetParent(_handObj);
                _canAdjustHand = false;
                _handObj.DOMove(_referencePoint.position, .25f).OnComplete(() => _canAdjustHand = true);
                if (_object.GetTransform().TryGetComponent(out IInteractable _interactable))
                {
                    _isHolding = true;
                    _interactable.Interact();
                }
            }
            else
            {
                if (_object.GetTransform().TryGetComponent(out IInteractable _interactable))
                {
                    _interactable.Interact();
                }
            }
        }
    }
    void Complete()
    {
        _handObj.GetChild(0).SetParent(null);
        _isHolding = false;
        _canAdjustHand = true;
    }
}
