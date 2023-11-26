using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IniciarCorrida : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    private void OnTriggerStay2D(Collider2D collider) {
        if(collider.CompareTag("Player") && !GameManager.Instance.GetCorrida) IniCorrida();
    }

    private void IniCorrida()
    {
        Debug.Log("IniciarCorrida");
        GameManager.Instance.SetCorrida(true); 
        ControladorCorrida.Instance.GerarPontoChegada();
        
        Destroy(parent);
    }
}
