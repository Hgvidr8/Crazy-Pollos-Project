using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] UnityEvent OnHit;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider)
        {
            OnHit.Invoke();
        }
    }
}
