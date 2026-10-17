using UnityEngine;

public class ObjectTest : MonoBehaviour, IObjectable
{
    public Transform GetTransform()
    {
        return transform;
    }

    public bool IsFromDistance()
    {
        throw new System.NotImplementedException();
    }
}
