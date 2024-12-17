using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlatform : MonoBehaviour
{
    private CharacterController characterController;  // Referencia al CharacterController
    private Transform platform;                      // Plataforma móvil actual
    private Vector3 lastPlatformPosition;           // Última posición conocida de la plataforma
    private bool isOnPlatform;                     // Indicador de si estamos en la plataforma

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Si estamos en una plataforma, sincronizamos el movimiento
        if (isOnPlatform && platform != null)
        {
            Vector3 platformMovement = platform.position - lastPlatformPosition;
            characterController.Move(platformMovement); // Mover al jugador con la plataforma
            lastPlatformPosition = platform.position;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Detectar si estamos tocando una plataforma móvil
        if (hit.collider.CompareTag("Platform"))
        {
            if (platform == null) // Solo asignamos si es una nueva plataforma
            {
                platform = hit.collider.transform;
                lastPlatformPosition = platform.position;
                isOnPlatform = true;
            }
        }
    }

    void LateUpdate()
    {
        // Verificar si seguimos sobre la plataforma
        if (platform != null && !IsGroundedOnPlatform())
        {
            platform = null;
            isOnPlatform = false;
        }
    }

    private bool IsGroundedOnPlatform()
    {
        // Comprobar si seguimos en contacto con la plataforma usando un Raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f))
        {
            return hit.collider.transform == platform;
        }
        return false;
    }
}

