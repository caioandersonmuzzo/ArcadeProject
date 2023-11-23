using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTrafego : MonoBehaviour
{
    [SerializeField] private List<Transform> esquina;
    [SerializeField] private Carro obejtoCarro;
    private Vector3 esqDest;
    private Vector3 esqRef;
    private Vector3 vetorSpawn;
    private float vetX;
    private float vetY;
    private int rand;
    private int count;

    private void Update() {
        if(count < 5)
        {
            Spawn();
            count++;
        }
    }

    private void Spawn()
    {
        SelecionarTransform();

        AleatorizarSpawn();

        //if()
        Carro _carro = Instantiate(obejtoCarro,vetorSpawn,new Quaternion(0f,0f,0f,0f));
        _carro.Iniciar(esquina,rand);

    }
    

    private void SelecionarTransform()
    {
        rand = Random.Range(0,esquina.Count);
        esqRef = esquina[rand].position;
        if(rand == esquina.Count-1) rand = 0;
        else rand += 1;
        esqDest = esquina[rand].position;
    }

    private void AleatorizarSpawn()
    {
        vetX = Random.Range(esqRef.x,esqDest.x);
        vetY = Random.Range(esqRef.y,esqDest.y);
        vetorSpawn = new Vector3(vetX,vetY,0f);
    }
}
