using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if(Time.timeScale == 1)
        {
           Time.timeScale = 0;
           GameManager.instance.SetCurrentState(GameManager.gameState.Pause);
        } else
        {
           Time.timeScale = 1;
            GameManager.instance.SetCurrentState(GameManager.gameState.Play);
        }
    }
}
