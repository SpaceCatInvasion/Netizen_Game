using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    public LayerMask groundLayer;
    public RespawnManager RespawnManager;

    //Private
    private float horizontalInput;
	private bool onGround;
    private Rigidbody2D playerRb;
    private bool dashed=false;
    private float knockTimer=0;
    private GunScript gunScript;
    private Vector2 knockDir;

    //Timers
    private float dashTimer = 0;
    private float regenJump = 0;
    private float regenDash = 0;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        gunScript = GetComponent<GunScript>();
        if(player1)
            Variables.player1 = gameObject;
        else
            Variables.player2 = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1)
            Variables.player1 = gameObject;
        else
            Variables.player2 = gameObject;
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
        regenJump -= Time.deltaTime;
        regenDash -= Time.deltaTime;

		if (regenJump <= 0)
		{
            //Ray2D jumpRay = new Ray2D(transform.position, Vector2.down);
            RaycastHit2D jumpRay = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
            if(jumpRay.collider != null)
            {
				onGround = true;
			}
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
                regenJump = 0.1f;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Period) && onGround) // p2 Jump
            {
                playerRb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                onGround = false;
                regenJump = 0.1f;
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
                    regenDash = 0.1f;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.N)) //p2 dash
                {
                    dashTimer = dashLength;
                    dashed = true;
                    regenDash = 0.1f;
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
            if (knockTimer>0)
            {
                playerRb.velocity = knockDir;
                knockTimer -= Time.deltaTime;
            }
            else if (dashTimer > 0)
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
            if (knockTimer > 0)
            {
                playerRb.velocity = knockDir;
                knockTimer -= Time.deltaTime;
            }
            else if (dashTimer > 0)
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


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (regenDash <= 0)
        {
            dashed = false;
        }
    }
    public void knockBack(Vector2 dir, float strength)
    {
        print("KNOCK");
        knockDir = dir*80*Mathf.Log(strength+1);
        knockTimer = strength;
        Variables.p1Priority = !player1;
        Variables.noPriority = false;
        if (knockTimer > 0.2f)
        {
            knockTimer = 0.2f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RespawnTrigger"))
        {
            if (player1)
            {
                RespawnManager.p1Respawn = true;
            }
            else
            {
                RespawnManager.p2Respawn = true;
            }
            gameObject.SetActive(false);
        }
    }
}