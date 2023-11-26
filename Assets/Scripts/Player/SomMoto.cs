using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioClip footstepSound;  // O som de passos
    public float stepDistance = 1f;   // A dist�ncia a percorrer antes de tocar o som novamente
    private float distanceCounter = 0f;  // Contador de dist�ncia

    private void Update()
    {
        // Certifique-se de que seu personagem tenha um componente CharacterController
        CharacterController characterController = GetComponent<CharacterController>();

        if (characterController.isGrounded)
        {
            // Se o personagem estiver no ch�o, incrementa o contador de dist�ncia
            distanceCounter += characterController.velocity.magnitude * Time.deltaTime;

            // Se a dist�ncia percorrida for maior que stepDistance, toque o som de passos e reinicie o contador
            if (distanceCounter >= stepDistance)
            {
                PlayFootstepSound();
                distanceCounter = 0f;
            }
        }
    }

    private void PlayFootstepSound()
    {
        // Certifique-se de ter um AudioSource no seu GameObject para reproduzir o som
        AudioSource audioSource = GetComponent<AudioSource>();

        // Certifique-se de ter um som atribu�do ao AudioClip
        if (audioSource != null && footstepSound != null)
        {
            // Toque o som de passos
            audioSource.PlayOneShot(footstepSound);
        }
    }
}