using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

   
    public GameObject tp1;
    public GameObject tp2;
    public bool telep;
    public GameObject player1;
    public GameObject player2;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }

    public void teleport(bool p1)
    {
        if (p1)
        {
            if (telep)
            {
                player1.transform.position = tp2.transform.position;
                timer = 0.5f;
            }
            else
            {
                player1.transform.position = tp1.transform.position;
                timer = 0.5f;
            }
        }
        else
        {
            if (telep)
            {
                player2.transform.position = tp2.transform.position;
                timer = 0.5f;
            }
            else
            {
                player2.transform.position = tp1.transform.position;
                timer = 0.5f;
            }
        }
    }

 //   private float distance()
 //   {
 //       return Vector2.Distance(tp1.transform.position, tp2.transform.position);
//    }

    
}
