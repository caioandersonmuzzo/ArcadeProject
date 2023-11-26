using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitoManager : MonoBehaviour
{
    [SerializeField] GameObject[] carros;
    public Transform[] caminho;
    [SerializeField] float cooldown;

    [SerializeField] LayerMask carColliders;
    Vector3 carDimensions;

    [SerializeField] int maxCars = 5;
    int currentCarAmount;

    int randomEsquina;
    int randomCar;
    Transform parent;

    void Start()
    {
        parent = transform.parent.Find("Carros").GetComponent<Transform>();

        StartCoroutine(SpawnCar());
    }

    

    IEnumerator SpawnCar()
    {
        yield return new WaitForSeconds(cooldown);
        randomEsquina = Random.Range(0, caminho.Length);
        randomCar = Random.Range(0, carros.Length);

        while (currentCarAmount >= maxCars || CanSpawn() == 0)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Trying to spawn again!");
        }

        GameObject carroClone = Instantiate(carros[randomCar], caminho[randomEsquina].position, Quaternion.identity, parent);
        carroClone.GetComponent<TransitoMovement>().nextEsquina = randomEsquina;
        currentCarAmount++;
        StartCoroutine(SpawnCar());
    }

    int CanSpawn()
    {
        //cria um collider trigger na hora para testar se tem um carro nessa posicao ja
        if (!Physics2D.BoxCast(caminho[randomEsquina].position, carDimensions * 2f, 0f, Vector2.zero, 0f, carColliders))
        {
            return 1;
        }

        return 0;
    }

    private void OnEnable()
    {
        foreach (Transform t in caminho)
        {
            ListEsquinas.Register(t);
        }
    }

    private void OnDisable()
    {
        foreach (Transform t in caminho)
        {
            ListEsquinas.Unregister(t);
        }
    }
}
