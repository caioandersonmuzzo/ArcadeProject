using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float idleSpeed = 0.3f;
    public float maxSpeed = 0.6f;
    private Rigidbody2D rbody;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var target = GameManager.Instance.player;
        var dir = target.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        var speed = Mathf.Lerp(idleSpeed,maxSpeed,Mathf.Clamp(dir.magnitude/10f,0,1));
        rbody.velocity = speed * new Vector2(dir.x, dir.y);
    }
}
