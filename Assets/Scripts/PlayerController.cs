using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed;

    float horizontalMove = 0f;
    bool jump = false;

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
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetBool("IsMoving", horizontalMove != 0);

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }

            collisionAccounted = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}
