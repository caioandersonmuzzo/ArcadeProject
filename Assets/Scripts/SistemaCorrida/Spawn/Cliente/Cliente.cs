using System.Collections.Generic;
using UnityEngine;

public class Cliente : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private void Awake() {
        _renderer = GetComponent<SpriteRenderer>();
    }
    private void Start() {
        Destroy(transform.parent.gameObject,ControladorCorrida.Instance.GetTempCliente);
        _renderer.color = new Color(Random.value,Random.value,Random.value);
    }
    private void OnTriggerEnter2D(Collider2D collider2D) {
        if(collider2D.CompareTag("Player"))
        {
            GameManager.Instance.RedVida();
            Destroy(transform.parent.gameObject);
        }
    }
    
}
