using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject successScreen;
    public GameObject failureScreen;

    public GameObject coin;

    public bool gameOver;

    bool gamePaused;

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        if (!gamePaused)
        {
            if (coin.GetComponent<CoinController>().coinCollected)
            {
                LevelWon();
            }
            //if (Boon.GetComponent<PlayerController>().handedApplication)
            //{
            //    GameObject.Find("Boon").transform.localScale = new Vector3(0, 0, 0);
            //}

            //if (Emily.GetComponent<PlayerController>().handedApplication)
            //{
            //    GameObject.Find("Emily").transform.localScale = new Vector3(0, 0, 0);
            //}

            //if (Boon.GetComponent<PlayerController>().handedApplication && Emily.GetComponent<PlayerController>().handedApplication)
            //{
            //    //PauseGame();
            //    successScreen.SetActive(true);
            //}
            //else
            //{
            //if (timeLeft > 0 && !gameOver)
            //{
            //    timeLeft -= Time.deltaTime;
            //    int roundedTime = (int)timeLeft;
            //    countdownText.GetComponent<Text>().text = "Application due in: " + "\n" + roundedTime;
            //}
            //else
            //{
            //    //PauseGame();
            //    GameOver();
            //}

            //}
        }

    }

    public void PauseGame()
    {
        //Time.timeScale = 0;
        gamePaused = true;
    }

    public void ContinueGame()
    {
        //Time.timeScale = 1;
        gamePaused = false;
    }

    public void LevelWon()
    {
        successScreen.SetActive(true);
    }

    public void GameOver()
    {
        gameOver = true;
        failureScreen.SetActive(true);
    }


}
