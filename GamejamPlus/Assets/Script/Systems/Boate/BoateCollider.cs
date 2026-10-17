using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BoateCollider : MonoBehaviour
{
    

    public PlayerInput input;
    public Transform playerTransform;
    [SerializeField]Transform startPoint;


    private void Update()
    {
        Debug.Log("BoateCollider Update called");
        if (input == null) return;

        foreach (var action in input.actions)
        {
            if (action.WasPressedThisFrame())
            {
                ChangePlayerPosition();
                break;
            }
        }
    }

    void ChangePlayerPosition()
    {
        Debug.Log("cHANGE POS ");

        playerTransform.position = startPoint.position;
        playerTransform.rotation = startPoint.rotation;
    }
}
