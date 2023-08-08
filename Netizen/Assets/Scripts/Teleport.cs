using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

   
    public GameObject tp1;
    public GameObject tp2;
    public bool telep;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void teleport()
    {
        if (telep == false)
        {
            player.transform.position = new Vector2(tp2.transform.position.x, tp2.transform.position.y);
        }
        else
        {
            player.transform.position = new Vector2(tp1.transform.position.x, tp1.transform.position.y);
        }
    }

 //   private float distance()
 //   {
 //       return Vector2.Distance(tp1.transform.position, tp2.transform.position);
//    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // transform.position = new Vector2(transform.position.x -9, transform.position.y + 0);
        teleport();
    }
}
