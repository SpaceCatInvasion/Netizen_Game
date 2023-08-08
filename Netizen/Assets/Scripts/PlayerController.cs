using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    public float dashSpeed;
    public float dashLength;
    public float stopDashDelay;

    //Private
    private float horizontalInput;
    private bool onGround;
    private Rigidbody2D playerRb;
    private bool dashed=false;

    //Timers
    private float dashTimer = 0;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1)
        {
            getPlayerDir(true);
            horizontalInput = Input.GetAxis("Horizontal");
            jump(true);
            dash(true);
            move(true);
        }
        else
        {
            getPlayerDir(false);
            horizontalInput = Input.GetAxis("Horizontal2");
            jump(false);
            dash(false);
            move(false);
        }
    }

    //Functions

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
    void dash(bool p1)
    {
        if (!dashed)
        {
            if (p1)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift)) //p1 dash
                {
                    dashTimer = dashLength;
                    dashed = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.B)) //p2 dash
                {
                    dashTimer = dashLength;
                    dashed = true;
                }
            }
        }

    }
    void getPlayerDir(bool p1)
    {
        
        if (p1)
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");
            if (inputX > 0)
            {
                if (inputY > 0)
                {
                    Variables.player1Direction = Variables.UpRight;
                }
                else if (inputY < 0)
                {
                    Variables.player1Direction = Variables.DownRight;
                }
                else
                {
                    Variables.player1Direction = Variables.Right;
                }
            }
            else if (inputX < 0)
            {
                if (inputY > 0)
                {
                    Variables.player1Direction = Variables.UpLeft;
                }
                else if (inputY < 0)
                {
                    Variables.player1Direction = Variables.DownLeft;
                }
                else
                {
                    Variables.player1Direction = Variables.Left;
                }
            }
            else
            {
                if (inputY > 0)
                {
                    Variables.player1Direction = Variables.Up;
                }
                else if (inputY < 0)
                {
                    Variables.player1Direction = Variables.Down;
                }
            }           
        }
        else
        {
            float inputX = Input.GetAxis("Horizontal2");
            float inputY = Input.GetAxis("Vertical2");
            if (inputX > 0)
            {
                if (inputY > 0)
                {
                    Variables.player2Direction = Variables.UpRight;
                }
                else if (inputY < 0)
                {
                    Variables.player2Direction = Variables.DownRight;
                }
                else
                {
                    Variables.player2Direction = Variables.Right;
                }
            }
            else if (inputX < 0)
            {
                if (inputY > 0)
                {
                    Variables.player2Direction = Variables.UpLeft;
                }
                else if (inputY < 0)
                {
                    Variables.player2Direction = Variables.DownLeft;
                }
                else
                {
                    Variables.player2Direction = Variables.Left;
                }
            }
            else
            {
                if (inputY > 0)
                {
                    Variables.player2Direction = Variables.Up;
                }
                else if (inputY < 0)
                {
                    Variables.player2Direction = Variables.Down;
                }
            }
        }
    }
    void move(bool p1)
    {
        if (p1)
        {
            if (dashTimer > 0)
            {
                if (Variables.player1Direction == 7) //Left Dash
                {
                    playerRb.velocity = new Vector2(-dashSpeed, playerRb.velocity.y);
                }
                else if (Variables.player1Direction == 5) //Down Dash
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x, -dashSpeed);
                }
                else if (Variables.player1Direction == 3) //Right Dash
                {
                    playerRb.velocity = new Vector2(dashSpeed, playerRb.velocity.y);
                }
                else if (Variables.player1Direction == 1) //Up Dash
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x,dashSpeed);
                }
                else if(Variables.player1Direction == 2) //Up Right
                {
                    playerRb.velocity = new Vector2(dashSpeed, dashSpeed);
                }
                else if (Variables.player1Direction == 4) //Down Right
                {
                    playerRb.velocity = new Vector2(dashSpeed, -dashSpeed);
                }
                else if(Variables.player1Direction == 6) //Down Left
                {
                    playerRb.velocity = new Vector2(-dashSpeed, -dashSpeed);
                }
                else if(Variables.player1Direction == 8) //Up Left
                {
                    playerRb.velocity = new Vector2(-dashSpeed, dashSpeed);
                }
                dashTimer -= Time.deltaTime;
            }
            else if (dashTimer>=-stopDashDelay)
            {
                playerRb.velocity = new Vector2(0, 0);
                dashTimer -= Time.deltaTime;
            }
            else
            {
                playerRb.velocity = new Vector2(1 * sideSpeed * horizontalInput, playerRb.velocity.y);
            }
        }
        else
        {
            if (dashTimer > 0)
            {
                if (Variables.player2Direction == 7) //Left Dash
                {
                    playerRb.velocity = new Vector2(-dashSpeed, playerRb.velocity.y);
                }
                else if (Variables.player2Direction == 5) //Down Dash
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x, -dashSpeed);
                }
                else if (Variables.player2Direction == 3) //Right Dash
                {
                    playerRb.velocity = new Vector2(dashSpeed, playerRb.velocity.y);
                }
                else if (Variables.player2Direction == 1) //Up Dash
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x, dashSpeed);
                }
                else if (Variables.player2Direction == 2) //Up Right
                {
                    playerRb.velocity = new Vector2(dashSpeed, dashSpeed);
                }
                else if (Variables.player2Direction == 4) //Down Right
                {
                    playerRb.velocity = new Vector2(dashSpeed, -dashSpeed);
                }
                else if (Variables.player2Direction == 6) //Down Left
                {
                    playerRb.velocity = new Vector2(-dashSpeed, -dashSpeed);
                }
                else if (Variables.player2Direction == 8) //Up Left
                {
                    playerRb.velocity = new Vector2(-dashSpeed, dashSpeed);
                }
                dashTimer -= Time.deltaTime;
            }
            else if (dashTimer >= -stopDashDelay)
            {
                playerRb.velocity = new Vector2(0, 0);
                dashTimer -= Time.deltaTime;
            }
            else
            {
                playerRb.velocity = new Vector2(1 * sideSpeed * horizontalInput, playerRb.velocity.y);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        dashed = false;
    }
}