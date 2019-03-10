using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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


            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
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
