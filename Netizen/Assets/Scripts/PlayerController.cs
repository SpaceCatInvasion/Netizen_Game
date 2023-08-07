using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ///* KeyBinds
    // * Index 0-3: WASD
    // * Index 4 Jump
    // * Index 5 Dash
    // * Index 6 Shoot
    // */
    //public List<char> keyBinds;

    //Public
    public bool player1;
    public float sideSpeed;
    public float jumpPower;
    public float dashDistance;

    //Private
    private float horizontalInput;
    private bool onGround;
    private Rigidbody2D playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player1)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            jump(true);
            dash(true);
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal2");
            jump(false);
            dash(false);
        }
        transform.Translate(Vector3.right * sideSpeed * horizontalInput * Time.deltaTime);

    }
    void jump(bool p1)
    {
        if (p1)
        {
            if (Input.GetKeyDown(KeyCode.C) && onGround) // p1 Jump
            {
                playerRb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                onGround = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Period) && onGround) // p2 Jump
            {
                playerRb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                onGround = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
    }

    void dash(bool p2)
    {
        if (p2)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) //p1 dash
            {
                playerRb.AddForce(Vector3.right * dashDistance * horizontalInput , ForceMode2D.Impulse);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.V)) //p2 dash
            {
                playerRb.AddForce(Vector3.right * dashDistance * horizontalInput, ForceMode2D.Impulse);
            }
        }
    }
}