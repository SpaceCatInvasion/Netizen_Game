using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporters : MonoBehaviour
{
    public Teleport mainScript;
    public bool tele;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (mainScript.timer <= 0)
        {
            if (collision.gameObject.CompareTag("Player1"))
            {
                mainScript.teleport(true);
                mainScript.telep = tele;
            }
            else if (collision.gameObject.CompareTag("Player2"))
            {
                mainScript.teleport(false);
                mainScript.telep = tele;
            }
        }
        // transform.position = new Vector2(transform.position.x -9, transform.position.y + 0);

    }
}
