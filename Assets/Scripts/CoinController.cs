using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    public bool coinCollected = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Coin trigger");
        if (other.GetComponent<PlayerController>())
        {
            Debug.Log("Player got coin");
            GameObject.Find("Coin").transform.localScale = new Vector3(0, 0, 0);
            coinCollected = true;
        }
    }
}
