using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

   
    public GameObject tp1;
    public GameObject tp2;
    public bool telep;
    public float timer = 0;
    public AudioSource teleportSource;


    // Start is called before the first frame update
    void Start()
    {
        teleportSource = GetComponent <AudioSource>(); 
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
                teleportSource.Play();
                Variables.player1.transform.position = tp2.transform.position+new Vector3(0,1,0);
                timer = 0.5f;
            }
            else
            {
                teleportSource.Play();
                Variables.player1.transform.position = tp1.transform.position + new Vector3(0, 1, 0);
                timer = 0.5f;
            }
        }
        else
        {
            if (telep)
            {
                teleportSource.Play();
                Variables.player2.transform.position = tp2.transform.position + new Vector3(0, 1, 0);
                timer = 0.5f;
            }
            else
            {
                teleportSource.Play();
                Variables.player2.transform.position = tp1.transform.position + new Vector3(0, 1, 0);
                timer = 0.5f;
            }
        }
    }

 //   private float distance()
 //   {
 //       return Vector2.Distance(tp1.transform.position, tp2.transform.position);
//    }

    
}
