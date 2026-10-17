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
    Vector3 _handPositionOnObj;

    private void FixedUpdate()
    {
        HandCast(out _object, out _handPositionOnObj);
        _handObj.DOMove(_handPositionOnObj, .25f);
        if (_object == null)
        {
            return;
        }
    }
    void HandCast(out IObjectable _objectOverride, out Vector3 _handPos)
    {
        RaycastHit _hit;
        if(Physics.Raycast(_cameraTransform.position, _cameraTransform.forward,out _hit, _maxDistance))
        {
            if(_hit.collider.TryGetComponent(out IObjectable _objectable))
            {
                _handPos = _hit.point;
                _objectOverride = _objectable;
                return;
            }
            Debug.DrawRay(_cameraTransform.position, _cameraTransform.forward * _maxDistance, Color.yellow, 0f);
        }
        _objectOverride = null;
        _handPos = _referencePoint.position;
    }
}
