using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcaoCarro : MonoBehaviour
{
    private Carro carro;
    private void OnTriggerEnter2D(Collider2D collider2D) {
        if(collider2D.CompareTag("Player"))
        {
            Debug.Log("Trigger");
            GameManager.Instance.RedVida();
            carro = GetComponentInParent<Carro>();
            carro.crashed = true;
            Destroy(this);
        }
    }
}
