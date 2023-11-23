using System;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 vetorDrift;
    private Vector2 vetorVelocidade;
    private float fatorDrift = 0.5f;
    private bool isDrifting;
    private bool isMovingBack;
    private float boost = 1f;


    #region Variaveis visíveis

    [SerializeField] private float desaceleracao = 1f;
    [SerializeField] private float centripeta = 50f;
    [SerializeField] private float velocidade = 5f;
    [Range(2f,20f)] public float ajusteDirecao = 2f;
    [Range(0.8f,1f)] public float drift = 0.9f;
    [Range(1f,2.5f)] public float aplicarBoost = 1f;
    
    #endregion


    #region Unity

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        isDrifting = false;
        isMovingBack = false;
    }

    private void Update() {
        GameManager.Instance.SetVelocidade(rb.velocity.magnitude);
        GameManager.Instance.SetVetVel(rb.velocity);
        GameManager.Instance.playerPos = transform.position;
    }

    private void FixedUpdate() {
        MoverFrente();
        MoverTras();
        Derrapar();
        Boost();
    }

    #endregion


    #region Movimentacao
    
    private void MoverFrente()
    {
        if(!isMovingBack&&!GameManager.Instance.GetAnimating)
        {
            vetorVelocidade = transform.up * Vector2.Dot(rb.velocity, transform.up);
            vetorDrift = transform.right * Vector2.Dot(rb.velocity,transform.right);

            if(!isDrifting)
            {
                rb.velocity =  vetorVelocidade + vetorDrift * fatorDrift;

                rb.AddForce(boost * transform.up * velocidade * PlayerInput.acelerar ,ForceMode2D.Force);
            }

            rb.MoveRotation(rb.rotation + centripeta * - PlayerInput.virar.x * Time.deltaTime * (float)Math.Log(rb.velocity.magnitude+1,ajusteDirecao));

            // Frear
            rb.velocity -= vetorVelocidade * PlayerInput.frear * Time.deltaTime * desaceleracao;

            if(System.Math.Round(rb.velocity.magnitude) == 0 && Math.Sign(Vector2.Dot(rb.velocity,transform.up)) > 0 && PlayerInput.frear != 0) isMovingBack = true;
        }
        
    }

    private void MoverTras()
    {
        if(isMovingBack&&!GameManager.Instance.GetAnimating)
        {
            // Andar pra trás
            vetorVelocidade = transform.up * Vector2.Dot(rb.velocity, transform.up);
            vetorDrift = transform.right * Vector2.Dot(rb.velocity,transform.right);

            if(!isDrifting)
            {
                rb.velocity =  vetorVelocidade + vetorDrift * fatorDrift;

                rb.AddForce(boost * transform.up * - velocidade * 0.25f * PlayerInput.frear ,ForceMode2D.Force);
            }

            rb.MoveRotation(rb.rotation + centripeta *  PlayerInput.virar.x * Time.deltaTime * (float)Math.Log(rb.velocity.magnitude+1,ajusteDirecao));

            // Frear
            rb.velocity -= vetorVelocidade * PlayerInput.acelerar * Time.deltaTime * desaceleracao;

            // Mudar essa porcaria aqgui |||
            if(System.Math.Round(rb.velocity.magnitude) == 0 && Math.Sign(Vector2.Dot(rb.velocity,transform.up)) < 0 && PlayerInput.acelerar != 0) isMovingBack = false;
        
        }
    }

    private void Derrapar()
    {
        if(PlayerInput.derrapar != 0) isDrifting = true;
        else isDrifting = false;
        
        if(isDrifting)
        {
            rb.velocity =  (vetorVelocidade + vetorDrift) * drift;
        }
    }

    private void Boost()
    {
        if(GameManager.Instance.GetIsBoosting)
        {
            boost = aplicarBoost;
        }
        else
        {
            boost = 1f;
        }
    }
    
    #endregion
}