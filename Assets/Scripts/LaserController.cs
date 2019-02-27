using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    public ColorsEnum color;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ColorsEnum blobColor = ColorsEnum.White;
        if (other.GetComponent<PlayerController>())
        {
            blobColor = other.GetComponent<PlayerController>().color;
        }
        else if (other.GetComponent<NPCController>())
        {
            blobColor = other.GetComponent<NPCController>().color;
        }
        if (color == blobColor)
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<CircleCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Physics2D.IgnoreCollision(other.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>(), false);
        Physics2D.IgnoreCollision(other.gameObject.GetComponent<CircleCollider2D>(), gameObject.GetComponent<BoxCollider2D>(), false);
    }

}