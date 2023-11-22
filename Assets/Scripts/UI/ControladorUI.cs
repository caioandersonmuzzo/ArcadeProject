using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorUI : MonoBehaviour
{
    private InputMap input;
    private static ControladorUI _instance;
    public static ControladorUI Instance => _instance;
    [SerializeField] private GameObject gameoverUI;
    [SerializeField] private GameObject temporizadorUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject miniMapUI;
    private bool isRunning;

    private void Awake() {
        if(_instance == null) _instance = this;
        else Destroy(this);

        input = new InputMap();
        
        isRunning = true;
    }

    private void OnEnable() {
        input.Enable();
        input.UI.Pause.started += Pause;
    }

    private void OnDisable() {
        input.Disable();
        input.UI.Pause.started -= Pause;
    }

    private void Update() {
        if(GameManager.Instance.GetGameOver) GameOver();
    }

    private void GameOver() // Implementar sistema de adicionar ficha
    {
        Time.timeScale = 0f;
        
        gameoverUI.SetActive(true);
        temporizadorUI.SetActive(false);

        Score.Instance.MudarScoreOver();
        miniMapUI.SetActive(false);


        isRunning = false;
    }

    private void Pause(InputAction.CallbackContext context)
    {
        if(isRunning) // Pause
        {
            Time.timeScale = 0f;
            isRunning = false;
            pauseUI.SetActive(true);
            temporizadorUI.SetActive(false);
            miniMapUI.SetActive(false);
            
            Score.Instance.MudarScorePause();

            return;
        }
        if(!isRunning) // Continue
        {
            Debug.Log(context.ReadValue<float>());
            Time.timeScale = 1f;
            isRunning = true;
            pauseUI.SetActive(false);
            temporizadorUI.SetActive(true);
            miniMapUI.SetActive(true);
            
            return;
        }
    }
}
