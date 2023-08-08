using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public bool player1;
    public GameObject bulletPreFab;

    private float chargeShot=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1)
        {
            if (Variables.player1Direction == 7) //Left
            {
                transform.up = new Vector2(-1, 0);
            }
            else if (Variables.player1Direction == 5) //Down
            {
                transform.up = new Vector2(0, -1);
            }
            else if (Variables.player1Direction == 3) //Right
            {
                transform.up = new Vector2(1, 0);
            }
            else if (Variables.player1Direction == 1) //Up
            {
                transform.up = new Vector2(0, 1);
            }
            else if (Variables.player1Direction == 2) //Up Right
            {
                transform.up = new Vector2(1, 1);
            }
            else if (Variables.player1Direction == 4) //Down Right
            {
                transform.up = new Vector2(1, -1);
            }
            else if (Variables.player1Direction == 6) //Down Left
            {
                transform.up = new Vector2(-1, -1);
            }
            else if (Variables.player1Direction == 8) //Up Left
            {
                transform.up = new Vector2(-1, 1);
            }
            if (Input.GetKey(KeyCode.V))
            {
                chargeShot += Time.deltaTime;
                print("Charging");
            }
            else if(Input.GetKeyUp(KeyCode.V))
            {
                if (chargeShot > 0.1f)
                {
                    MoveForward bul = Instantiate(bulletPreFab, transform.position, transform.rotation).GetComponent<MoveForward>();
                    if (chargeShot > 2)
                    {
                        bul.size = 0.5f;
                        bul.speed = 2;
                    }
                    else if (chargeShot > 0.8f)
                    {
                        bul.size = 0.3f;
                        bul.speed = 5;
                    }
                    else
                    {
                        bul.size = 0.1f;
                        bul.speed = 7;
                    }
                }
                chargeShot = 0;
            }
            
        }
        else
        {
            if (Variables.player2Direction == 7) //Left
            {
                transform.up = new Vector2(-1, 0);
            }
            else if (Variables.player2Direction == 5) //Down
            {
                transform.up = new Vector2(0, -1);
            }
            else if (Variables.player2Direction == 3) //Right
            {
                transform.up = new Vector2(1, 0);
            }
            else if (Variables.player2Direction == 1) //Up
            {
                transform.up = new Vector2(0, 1);
            }
            else if (Variables.player2Direction == 2) //Up Right
            {
                transform.up = new Vector2(1, 1);
            }
            else if (Variables.player2Direction == 4) //Down Right
            {
                transform.up = new Vector2(1, -1);
            }
            else if (Variables.player2Direction == 6) //Down Left
            {
                transform.up = new Vector2(-1, -1);
            }
            else if (Variables.player2Direction == 8) //Up Left
            {
                transform.up = new Vector2(-1, 1);
            }
        }
    }
}
