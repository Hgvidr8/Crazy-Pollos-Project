using UnityEngine;
using UnityEngine.Events;
public class WoodNail : MonoBehaviour
{
    [SerializeField] int _nailIndex;
    [SerializeField] UnityEvent OnNailsOut;
    public void SetIndex()
    {
        _nailIndex++;
        SetRb();
    }
    void SetRb()
    {
        if(_nailIndex >= 4)
        {
            gameObject.AddComponent<ObjectTest>();
            OnNailsOut.Invoke();
        }
    }
}
