using UnityEngine;

public class BoateCollider : MonoBehaviour
{
    Transform startPoint;

    private void OnCollisionStay(Collision collision)
    {
        //collision.gameObject.TryGetComponent<coisa do player>(out Transform t);
        //t = startPoint;
    }
}
