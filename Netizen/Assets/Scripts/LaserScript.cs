using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float timer=-1;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer > -1)
        {
            timer = -1;
            gameObject.SetActive(false);
        }
        print("Timer: "+timer);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            PlayerController script = Variables.player1.gameObject.GetComponent<PlayerController>();
            int x;
            int y;
            if (gameObject.transform.position.x > Variables.player1.gameObject.transform.position.x)
            {
                x = -2;
            }
            else
            {
                x = 2;
            }
            if (gameObject.transform.position.y > Variables.player1.gameObject.transform.position.y)
            {
                y=-2;
            }
            else
            {
                y = 2;
            }
            script.knockBack(new Vector2(x,y), 0.2f);
            if(timer>0.5)
                timer = 0.2f;
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            PlayerController script = Variables.player2.gameObject.GetComponent<PlayerController>();
            int x;
            int y;
            if (gameObject.transform.position.x > Variables.player2.gameObject.transform.position.x)
            {
                x = -2;
            }
            else
            {
                x = 2;
            }
            if (gameObject.transform.position.y > Variables.player2.gameObject.transform.position.y)
            {
                y = -2;
            }
            else
            {
                y = 2;
            }
            script.knockBack(new Vector2(x, y), 0.2f);
            if(timer>0.5)
                timer = 0.2f;
        }
    }
}
