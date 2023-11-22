using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItens : MonoBehaviour
{
    [SerializeField] private GameObject manchaOleo;
    [SerializeField] private GameObject boost;
    [SerializeField] private Transform infEsq;
    [SerializeField] private Transform supDir;
    [SerializeField] private float limiteSpawn;
    // Quanto maior, menor a chance
    [SerializeField] private float chanceSpawnOleo = 1f;
    // Quanto maior, menor a chance
    [SerializeField] private float chanceSpawnBoost = 1f;
    private Vector3 vetorSpawn;
    private float controlSpawn;
    private bool firstTime;

    private void Awake() {
        firstTime = true;
    }

    private void Update() {
        Spawn();
        Debug.Log((GameManager.Instance.playerPos - transform.position).magnitude);
    }

    private void Spawn()
    {
        if((GameManager.Instance.playerPos - transform.position).magnitude < limiteSpawn 
        && (GameManager.Instance.playerPos - transform.position).magnitude > limiteSpawn * 0.25f && (Time.time > controlSpawn || firstTime))
        {
            vetorSpawn = new Vector3(Random.Range(infEsq.position.x,supDir.position.x),Random.Range(infEsq.position.y,supDir.position.y),0f);
            if(Random.value>=0.3 && Random.value < 1f/chanceSpawnOleo)
            {
                Instantiate(manchaOleo,vetorSpawn,new Quaternion(0f,0f,0f,0f));
            }
            else if(Random.value<0.3 && Random.value < 1f/chanceSpawnBoost)
            {
                Instantiate(boost,vetorSpawn,new Quaternion(0f,0f,0f,0f));
            }

            firstTime = false;

            controlSpawn = Time.time + ControladorCorrida.Instance.GetTempCliente;
        }
    }


}
