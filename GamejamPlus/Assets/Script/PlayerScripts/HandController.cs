using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class HandController : MonoBehaviour
{
    [SerializeField] SplineContainer _spline;
    [SerializeField] BezierKnot[] _knot;
    [SerializeField] Transform _cameraTransform;
    [SerializeField] Transform _point;
    [SerializeField] float _maxDistance;
    IInteractable _interactable;
    private void Start()
    {
        _knot = new BezierKnot[3];
        _point.position = _cameraTransform.position;
    }
    private void FixedUpdate()
    {
        _interactable = GetInteractable();
        HandInput();
    }
    public void HandInput()
    {
        if(_interactable == null)
        {
            return;
        }
        //_point.position = Vector3.Lerp(_point.position, _interactable.GetTransform().position, .25f); 

        _knot[0].Position = _point.position;
        _knot[1].Position = new Vector3((_point.position.x + _cameraTransform.position.x)/ 2, 0f, (_point.position.z + _cameraTransform.position.z)/2);
        _knot[2].Position = _cameraTransform.position;

        _spline.Spline.SetKnot(0, _knot[0]);
        _spline.Spline.SetKnot(1, _knot[1]);
        _spline.Spline.SetKnot(2, _knot[2]);
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed && _interactable != null)
        {
            _interactable.Interact();
            //_interactable.GetTransform().transform.position = _point.position;
        }
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
