using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitoManager : MonoBehaviour
{
    [SerializeField] GameObject carro;
    [SerializeField] Transform[] caminho;
    [SerializeField] float cooldown;

    int random;
    Transform parent;

    void Start()
    {
        parent = transform.Find("Carros").GetComponent<Transform>();

        StartCoroutine(SpawnCar());
    }

    IEnumerator SpawnCar()
    {
        yield return new WaitForSeconds(cooldown/2f);
        random = Random.Range(0, caminho.Length);
        GameObject carroClone = Instantiate(carro, caminho[random].position, Quaternion.identity, parent);
        carroClone.GetComponent<TransitoMovement>().nextEsquina = random;
        yield return new WaitForSeconds(cooldown/2f);
        StartCoroutine(SpawnCar());
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
