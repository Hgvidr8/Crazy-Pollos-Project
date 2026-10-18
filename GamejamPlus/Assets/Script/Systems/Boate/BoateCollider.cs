using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BoateCollider : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform startPoint;
    [SerializeField] private CharacterController characterController;

    [Header("Configurações")]
    [SerializeField] private float checkInterval = 0.1f;
    [SerializeField] private float maxDistance = 10f;

    private Vector3 savedPosition;
    private float timer;

    private bool isChecking = false;

    private void Update()
    {
        if (!isChecking)
            return;

        timer += Time.deltaTime;

        if (timer >= checkInterval)
        {
            //timer = 0f;
            CheckPlayerPosition();
        }
    }

    public void StartChecking()
    {
        savedPosition = player.position;
        timer = 0f;
        isChecking = true;
    }

    public void StopChecking()
    {
        isChecking = false;
        savedPosition = Vector3.zero;
        timer = 0f;
    }

    private void CheckPlayerPosition()
    {
        float distance = Vector3.Distance(
            savedPosition,
            player.position
        );

        if (distance >= maxDistance)
        {
            TeleportPlayer();
        }
    }

    private void TeleportPlayer()
    {
        if (characterController != null)
        {
            characterController.enabled = false;
            player.position = startPoint.position;
            characterController.enabled = true;
        }
        else
        {
            player.position = startPoint.position;
        }

        savedPosition = player.position;
    }
}
