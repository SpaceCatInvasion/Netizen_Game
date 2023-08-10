using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public bool player1;
    public GameObject bulletPreFab;
    public AudioSource gunSource;

    private Vector2 dir;
    private float chargeShot=0;
    // Start is called before the first frame update
    void Start()
    {
        gunSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Variables.startedGame)
        {
            if (player1)
            {
                if (Variables.player1Direction == 7) //Left
                {
                    dir = new Vector2(-1, 0);
                    transform.up = dir;
                }
                else if (Variables.player1Direction == 5) //Down
                {
                    dir = new Vector2(0, -1);
                    transform.up = dir;
                }
                else if (Variables.player1Direction == 3) //Right
                {
                    dir = new Vector2(1, 0);
                    transform.up = dir;
                }
                else if (Variables.player1Direction == 1) //Up
                {
                    dir = new Vector2(0, 1);
                    transform.up = dir;
                }
                else if (Variables.player1Direction == 2) //Up Right
                {
                    dir = new Vector2(1, 1);
                    transform.up = dir;
                }
                else if (Variables.player1Direction == 4) //Down Right
                {
                    dir = new Vector2(1, -1);
                    transform.up = dir;
                }
                else if (Variables.player1Direction == 6) //Down Left
                {
                    dir = new Vector2(-1, -1);
                    transform.up = dir;
                }
                else if (Variables.player1Direction == 8) //Up Left
                {
                    dir = new Vector2(-1, 1);
                    transform.up = dir;
                }
                if (Input.GetKey(KeyCode.V))
                {
                    chargeShot += Time.deltaTime;
                }
                else if (Input.GetKeyUp(KeyCode.V))
                {
                    if (chargeShot > 0.05f)
                    {
                        gunSource.Play();
                        MoveForward bul = Instantiate(bulletPreFab, transform.position + new Vector3(dir.x, dir.y, 0), transform.rotation).GetComponent<MoveForward>();
                        bul.dir = dir;
                        if (chargeShot > 1.4f)
                        {
                            bul.size = 0.4f;
                            bul.speed = 7;
                        }
                        else if (chargeShot > 0.7f)
                        {
                            bul.size = 0.2f;
                            bul.speed = 11;
                        }
                        else
                        {
                            bul.size = 0.1f;
                            bul.speed = 16;
                        }
                    }
                    chargeShot = 0;
                }

            }
            else
            {
                if (Variables.player2Direction == 7) //Left
                {
                    dir = new Vector2(-1, 0);
                    transform.up = dir;
                }
                else if (Variables.player2Direction == 5) //Down
                {
                    dir = new Vector2(0, -1);
                    transform.up = dir;
                }
                else if (Variables.player2Direction == 3) //Right
                {
                    dir = new Vector2(1, 0);
                    transform.up = dir;
                }
                else if (Variables.player2Direction == 1) //Up
                {
                    dir = new Vector2(0, 1);
                    transform.up = dir;
                }
                else if (Variables.player2Direction == 2) //Up Right
                {
                    dir = new Vector2(1, 1);
                    transform.up = dir;
                }
                else if (Variables.player2Direction == 4) //Down Right
                {
                    dir = new Vector2(1, -1);
                    transform.up = dir;
                }
                else if (Variables.player2Direction == 6) //Down Left
                {
                    dir = new Vector2(-1, -1);
                    transform.up = dir;
                }
                else if (Variables.player2Direction == 8) //Up Left
                {
                    dir = new Vector2(-1, 1);
                    transform.up = dir;
                }
                if (Input.GetKey(KeyCode.RightShift))
                {
                    chargeShot += Time.deltaTime;
                }
                else if (Input.GetKeyUp(KeyCode.RightShift))
                {
                    if (chargeShot > 0.05f)
                    {
                        gunSource.Play();
                        MoveForward bul = Instantiate(bulletPreFab, transform.position + new Vector3(dir.x, dir.y, 0), transform.rotation).GetComponent<MoveForward>();
                        bul.dir = dir;
                        if (chargeShot > 1.4f)
                        {
                            bul.size = 0.4f;
                            bul.speed = 4;
                        }
                        else if (chargeShot > 0.7f)
                        {
                            bul.size = 0.2f;
                            bul.speed = 7;
                        }
                        else
                        {
                            bul.size = 0.1f;
                            bul.speed = 10;
                        }
                    }
                    chargeShot = 0;
                }
            }
        }
    }
}
