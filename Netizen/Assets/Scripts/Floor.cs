using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private float crumbleTimer=-1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(crumbleTimer > 0)
        {
            crumbleTimer -= Time.deltaTime;
        }
        else if(crumbleTimer > -1)
        {
            gameObject.SetActive(false);
            crumbleTimer = - 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        crumbleTimer = 1.5f;
    }
}
