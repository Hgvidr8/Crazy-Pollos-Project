using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class HandController : MonoBehaviour
{
    public static HandController instance;

    public IObjectable _object;
    public Transform _referencePoint;
    public Transform _cameraTransform;
    public Transform _handObj;
    public float _maxDistance;
    public Hand _hand;
    public bool _isHolding;
    public bool _canAdjustHand = true;
    Vector3 _handPositionOnObj;
    private void Awake()
    {
        instance = this;
    }
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
        _hand.Interact(context);
    }
}
