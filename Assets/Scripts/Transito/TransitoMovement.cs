using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitoMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float rotationSpeed;
    bool canRotate;

    List<Transform> caminho; //tem todo o caminho de esquinas que os carros percorrerao
    public int nextEsquina = 0; //diz em qual esquina estamos

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        caminho = ListEsquinas.GetPath();
    }

    void FixedUpdate()
    {
        WalkToEsquina();

        if (canRotate)
        {
            //rotacao
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, caminho[nextEsquina].position - transform.position);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rb.MoveRotation(rotation);
        }
    }

    void WalkToEsquina()
    {
        if (nextEsquina < caminho.Count) //se o carro nao estiver na ultima esquina
        {
            //se move ate a proxima esquina
            transform.position = Vector2.MoveTowards(transform.position,
                caminho[nextEsquina].position,
                moveSpeed * Time.deltaTime);

            //se o carro estiver na esquina que deveria chegar
            if (transform.position == caminho[nextEsquina].position)
            {
                StartCoroutine(TurningToNextTarget(moveSpeed));
            }
        }
    }

    //Gira o carro para ir na direcao certa
    IEnumerator TurningToNextTarget(float trueSpeed) //trueSpeed serve para guardar a velocidade antiga
    {
        moveSpeed = 0f; // trava o carro no lugar para girar tranquilamente
        nextEsquina++; //avanca na lista de esquinas

        //se a proxima esquina for de um numero maior que a ultima esquina, reinicia o percurso
        if (nextEsquina == caminho.Count)
        {
            nextEsquina = 0;
        }

        canRotate = true;

        yield return new WaitForSeconds(1f);

        canRotate = false;
        moveSpeed = trueSpeed; //retorna a velocidade ao carro
    }
}
