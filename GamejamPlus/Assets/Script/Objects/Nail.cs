using UnityEngine;
using UnityEngine.Events;

public class Nail : MonoBehaviour, INaileable, IObjectable
{
    [SerializeField] UnityEvent NailOut;
    public Transform GetTransform()
    {
        return transform;
    }

    public bool IsFromDistance()
    {
        return false;
    }

    public void OnNailOut()
    {
        NailOut.Invoke();
    }
}
