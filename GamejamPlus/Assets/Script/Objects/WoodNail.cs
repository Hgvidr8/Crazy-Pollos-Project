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
            ObjectTest _objTest = gameObject.AddComponent<ObjectTest>();
            _objTest.
            OnNailsOut.Invoke();
        }
    }
}
