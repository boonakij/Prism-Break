using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed;

    float horizontalMove = 0f;
    bool jump = false;

    public bool runningRight;

    public bool handedApplication = false;

    public bool gamePaused;

    public bool collisionAccounted = false;

    public ColorsEnum color;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!gamePaused)
        {
            if (runningRight)
            {
                horizontalMove = 1 * runSpeed;
            }
            else
            {
                horizontalMove = -1 * runSpeed;
            }

            animator.SetBool("IsMoving", horizontalMove != 0);
            collisionAccounted = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!collisionAccounted)
        {
            if (other.gameObject.tag == "Blob")
            {
                Color temp = gameObject.GetComponent<SpriteRenderer>().color;
                ColorsEnum temp2 = color;
                gameObject.GetComponent<SpriteRenderer>().color = other.gameObject.GetComponent<SpriteRenderer>().color;
                if (other.gameObject.GetComponent<NPCController>())
                {
                    color = other.gameObject.GetComponent<NPCController>().color;
                    other.gameObject.GetComponent<NPCController>().color = temp2; 
                }
                else
                {
                    color = other.gameObject.GetComponent<PlayerController>().color;
                    other.gameObject.GetComponent<PlayerController>().color = temp2;
                }
                
                other.gameObject.GetComponent<SpriteRenderer>().color = temp;

                if (other.gameObject.GetComponent<NPCController>())
                {
                    other.gameObject.GetComponent<NPCController>().runningRight = !other.gameObject.GetComponent<NPCController>().runningRight;
                    other.gameObject.GetComponent<NPCController>().collisionAccounted = true;
                }
            }
            runningRight = !runningRight;
        }
    }
}
