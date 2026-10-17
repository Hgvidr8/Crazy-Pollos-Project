using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class HandController : MonoBehaviour
{
    [SerializeField] IObjectable _object;
    [SerializeField] Transform _referencePoint;
    [SerializeField] Transform _cameraTransform;
    [SerializeField] float _maxDistance;

    private void FixedUpdate()
    {
        HandCast(out _object);
        if(_object == null)
        {
            return;
        }
        print(_object.GetTransform().name);
    }
    void HandCast(out IObjectable _object)
    {
        RaycastHit _hit;
        if(Physics.Raycast(_cameraTransform.position, _cameraTransform.forward,out _hit, _maxDistance))
        {
            if(_hit.collider.TryGetComponent(out IObjectable _objectable))
            {
                _object = _objectable;
                return;
            }
            Debug.DrawRay(_cameraTransform.position, _cameraTransform.forward * _maxDistance, Color.yellow, 0f);
        }
        _object = null;
    }
}
