using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TransitoManager tmanager;
    public float timerPolicia = 60f;
    private float timer;
    public Transform policiaPrefab;
    void Start()
    {
        timer = timerPolicia;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            timer = timerPolicia;
            Instantiate(policiaPrefab, tmanager.caminho[(int)Random.Range(0, tmanager.caminho.Length)].position,Quaternion.identity);
        }
        timer -= Time.deltaTime;
    }
}
