using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDerrapar : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        
    }

    
}
