using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mancha : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player"))
        {
            Animacao.Instance.Escorregar();
            GameManager.Instance.RedVida();
            Destroy(gameObject);
        }
    }
}
