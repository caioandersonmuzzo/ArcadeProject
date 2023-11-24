using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region var
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    // Variáveis de controle
    private float velocidade;
    private float tempoBoost;
    private float timerBoost;
    private Vector2 vetorVelocidade;
    private bool gameOver;
    private bool isAnimating;
    private bool isBoosting;
    private bool corrida;
    public Vector3 playerPos {set; get;}
    public Transform player;

    [SerializeField] private int vida = 5; 
    [SerializeField] private float timerJogo = 10f; // segundos

    #endregion

    #region unity

    private void Awake() {
        if(_instance == null) _instance = this;
        else Destroy(this);

        corrida = false;
        gameOver = false;
    }

    private void Update() {
        Temporizador();
        if(vida <= 0 || timerJogo == 0) gameOver = true;

        if(isBoosting) ControleBoost();
    }
    #endregion

    private void Temporizador()
    {
        if(!gameOver)
        {
            if(timerJogo > 0) timerJogo -= Time.deltaTime;
            else
            {
                timerJogo = 0f;
                gameOver = true;
            }
        }
    }
    public void AddTempoBoosting(float add) {tempoBoost += add;}
    public void AddTimer(float add) {timerJogo += add;}
    public void RedVida() {vida -= 1;}
    private void ControleBoost()
    {
        if(Time.time > timerBoost + tempoBoost)
        {
            isBoosting = false;
            tempoBoost = 0f;
        }
    }
    public void InicioBoost()
    {
        timerBoost = Time.time;
        isBoosting = true;
    }

    #region GetSet

    public void SetAnimating(bool a) {isAnimating = a;}
    public void SetVelocidade(float vel) {velocidade = vel;}
    public void SetVetVel(Vector2 vel) {vetorVelocidade = vel;}
    public void SetCorrida(bool corrida) {this.corrida = corrida;}
    public float GetTimer => timerJogo;
    public bool GetAnimating => isAnimating;
    public float GetVelocidade => velocidade;
    public Vector2 GetVetVel => vetorVelocidade;
    public bool GetCorrida => corrida;
    public int GetVida => vida;
    public bool GetGameOver => gameOver;
    public bool GetIsBoosting =>isBoosting;


    #endregion
}
