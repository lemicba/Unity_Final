using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum gameState
    {
        Play,
        Pause,
        GameOver
    }
    private gameState currentState;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
            
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        switch (currentState)
        {
            case gameState.Play:
                Debug.Log("tareas del play");
                break;
            case gameState.Pause:
                Debug.Log("tareas del pause");
                break;
            case gameState.GameOver:
                Debug.Log("tareas del game over");
                break;
        }
    }

    public void SetCurrentState(gameState state)
    {
        currentState = state;
    }
    public gameState GetGameState()
    {
        return currentState;
    }

}
