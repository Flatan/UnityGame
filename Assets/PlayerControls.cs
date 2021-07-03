using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    bool canJump = false;
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            body.AddForce(new Vector2(-10, 0) );
        }
        else if (Input.GetKey("d"))
        {
            body.AddForce(new Vector2(10, 0) );
        }

        if (Input.GetKey("space") && canJump)
        {
            body.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }


}
