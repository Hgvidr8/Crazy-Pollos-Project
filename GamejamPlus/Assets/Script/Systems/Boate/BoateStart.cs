using UnityEngine;
using UnityEngine.Events;

public class BoateStart : MonoBehaviour
{

    public UnityEvent Evento;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Evento?.Invoke();
        }
    }
}
