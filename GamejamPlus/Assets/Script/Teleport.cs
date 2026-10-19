using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform player;
    [SerializeField] private Transform teleportPoint;
    private void TeleportPlayer()
    {
        if (characterController != null)
        {
            characterController.enabled = false;
            player.position = teleportPoint.position;
            characterController.enabled = true;
        }
        else
        {
            player.position = teleportPoint.position;
        }
    }
}
