using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public bool player1;
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
